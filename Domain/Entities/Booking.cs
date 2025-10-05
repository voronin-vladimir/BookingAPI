using System;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}