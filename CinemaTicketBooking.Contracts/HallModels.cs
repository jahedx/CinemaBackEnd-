using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Contracts
{
    public class CreateHallRequest
    {
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public int CinemaId { get; set; }
    }

    public class UpdateHallRequest
    {
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public int CinemaId { get; set; }
    }

    public class HallResponse
    {
        public int HallId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int CinemaId { get; set; }
        public string CinemaName { get; set; }
    }
} 