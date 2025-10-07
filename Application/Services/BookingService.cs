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
        private readonly IRoomRepository _roomRepository;

        public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }

        public async Task<BookingDto?> BookRoom(string userId, int roomId, DateTime start, DateTime end)
        {
            var room = await _roomRepository.GetById(roomId);
            if (room == null)
                throw new Exception("No room");

            var existingRoomBookings = await _bookingRepository.GetBookingsByRoom(roomId);
            var hasOverlap = existingRoomBookings.Any(b => start < b.EndDate && end > b.StartDate);

            if (hasOverlap)
                throw new Exception("Has overlap");

            var booking = new Booking
            {
                UserId = userId,
                RoomId = roomId,
                StartDate = start,
                EndDate = end,
                CreatedAt = DateTime.UtcNow
            };

            await _bookingRepository.BookRoom(booking);

            var dto = GetDto(booking);
            return dto;
        }

        public async Task<BookingDto?> GetBooking(int id)
        {
            var booking = await _bookingRepository.GetBooking(id);

            if (booking == null)
                return null;

            var dto = GetDto(booking);
            return dto;
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByUser(string userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUser(userId);

            return bookings.Select(GetDto);
        }

        private static BookingDto GetDto(Booking booking)
        {
            return new BookingDto
            {
                Id = booking.Id,
                UserId = booking.UserId,
                RoomId = booking.RoomId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate
            };
        }
    }
}