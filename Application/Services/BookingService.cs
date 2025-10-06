using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository) =>
            _bookingRepository = bookingRepository;

        public async Task<Booking?> BookRoom(string userId, int roomId, DateTime start, DateTime end)
        {
            var booking = new Booking
            {
                UserId = userId,
                RoomId = roomId,
                StartDate = start,
                EndDate = end,
                CreatedAt = DateTime.UtcNow
            };

            await _bookingRepository.BookRoom(booking);
            return booking;
        }

        public async Task<BookingDto?> GetBooking(int id)
        {
            var booking = await _bookingRepository.GetBooking(id);

            if (booking == null)
                return null;
            
            var dto = new BookingDto
            {
                Id = booking.Id,
                UserId = booking.UserId,
                RoomId = booking.RoomId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate
            };
            return dto;
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByUser(string userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUser(userId);

            return bookings.Select(b => new BookingDto
            {
                Id = b.Id,
                UserId = b.UserId,
                RoomId = b.RoomId,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
            });
        }
    }
}