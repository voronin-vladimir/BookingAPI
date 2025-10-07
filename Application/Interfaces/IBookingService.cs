using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDto?> BookRoom(string userId, int roomId, DateTime start, DateTime end);
        Task<BookingDto?> GetBooking(int id);
        Task<IEnumerable<BookingDto>> GetBookingsByUser(string userId);
    }
}