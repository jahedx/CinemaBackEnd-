using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Contracts
{
    public class CreateCinemaRequest
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Address { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string Phone { get; set; }
        [Required]
        public required string Email { get; set; }
    }

    public class UpdateCinemaRequest
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Address { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string Phone { get; set; }
        [Required]
        public required string Email { get; set; }
    }

    public class CinemaResponse
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int HallCount { get; set; }
    }
} 