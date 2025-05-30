using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Contracts
{
    public enum UserRole
    {
        [Display(Name = "Customer")]
        Customer = 0,
        [Display(Name = "Cinema Manager")]
        CinemaManager = 1,
        [Display(Name = "Admin")]
        Admin = 2
    }

    public class RegisterRequest
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Phone]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }

    public class AuthResponse
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string? Message { get; set; }
        public UserResponse? User { get; set; }
    }

    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
} 