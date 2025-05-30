using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;
using CinemaTicketBooking.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserMapper _userMapper;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _userMapper = new UserMapper();
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
            {
                return new AuthResponse { Success = false, Message = "Username already exists" };
            }

            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return new AuthResponse { Success = false, Message = "Email already exists" };
            }

            if (!IsValidRole(request.Role))
            {
                return new AuthResponse { Success = false, Message = "Invalid role. Allowed roles are: Customer, Cinema Manager, Admin" };
            }

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
                CreatedAt = DateTime.UtcNow
            };

            user.PasswordHash = HashPassword(request.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            return new AuthResponse
            {
                Success = true,
                Token = token,
                RefreshToken = refreshToken,
                User = _userMapper.ToResponse(user)
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null)
            {
                return new AuthResponse { Success = false, Message = "Invalid username or password" };
            }

            if (!VerifyPassword(request.Password, user.PasswordHash))
            {
                return new AuthResponse { Success = false, Message = "Invalid username or password" };
            }

            if (!string.Equals(user.Role, request.Role, StringComparison.OrdinalIgnoreCase))
            {
                return new AuthResponse { Success = false, Message = "Invalid role" };
            }

            var token = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            return new AuthResponse
            {
                Success = true,
                Token = token,
                RefreshToken = refreshToken,
                User = _userMapper.ToResponse(user)
            };
        }

        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return new AuthResponse { Success = false, Message = "Invalid refresh token" };
            }

            var token = GenerateJwtToken(user);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            return new AuthResponse
            {
                Success = true,
                Token = token,
                RefreshToken = newRefreshToken,
                User = _userMapper.ToResponse(user)
            };
        }

        private bool IsValidRole(string role)
        {
            return role.Equals("Customer", StringComparison.OrdinalIgnoreCase) ||
                   role.Equals("Cinema Manager", StringComparison.OrdinalIgnoreCase) ||
                   role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not found")));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
} 