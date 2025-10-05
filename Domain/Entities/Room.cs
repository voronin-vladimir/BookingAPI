using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public RoomClass Class { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}