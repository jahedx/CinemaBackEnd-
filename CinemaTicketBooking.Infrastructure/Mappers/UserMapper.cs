using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;

namespace CinemaTicketBooking.Infrastructure.Mappers
{
    public class UserMapper
    {
        public UserResponse? ToResponse(User? user)
        {
            if (user == null)
                return null;

            return new UserResponse
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }

        public User? ToEntity(CreateUserRequest? request)
        {
            if (request == null)
                return null;

            return new User
            {
                Username = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
                CreatedAt = DateTime.UtcNow
            };
        }

        public void UpdateEntity(User? user, UpdateUserRequest? request)
        {
            if (user == null || request == null)
                return;

            user.Email = request.Email ?? user.Email;
            user.FirstName = request.FirstName ?? user.FirstName;
            user.LastName = request.LastName ?? user.LastName;
            user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
            user.Role = request.Role ?? user.Role;
        }
    }
} 