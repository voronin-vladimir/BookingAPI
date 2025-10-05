using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        public Task<Booking?> BookRoom(string userId, int roomId, DateTime start, DateTime end) =>
            throw new NotImplementedException();

        public Task<Booking?> GetBooking(int id) => throw new NotImplementedException();

        public Task<IEnumerable<Booking>> GetBookingsByUser(string userId) =>
            throw new NotImplementedException();
    }
}