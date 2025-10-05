using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> BookRoom(string userId, int roomId, DateTime start, DateTime end);
        Task<Booking?> GetBooking(int id);
        Task<IEnumerable<Booking>> GetBookingsByUser(string userId);
    }
}