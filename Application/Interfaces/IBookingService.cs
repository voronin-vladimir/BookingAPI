using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> BookRoom(string userId, int roomId, DateTime start, DateTime end);
        Task<BookingDto?> GetBooking(int id);
        Task<IEnumerable<BookingDto>> GetBookingsByUser(string userId);
    }
}