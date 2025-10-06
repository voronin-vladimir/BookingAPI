using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService) => _bookingService = bookingService;

        [HttpPost]
        public async Task<IActionResult> Book([FromQuery] string userId, [FromQuery] int roomId,
            DateTime start, DateTime end)
        {
            var booking = await _bookingService.BookRoom(userId, roomId, start, end);
            return booking is null ? BadRequest("Room already booked for these dates") : Ok(booking);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await _bookingService.GetBooking(id);
            return booking is null ? BadRequest($"No booking with id: {id}") : Ok(booking);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBookings(string userId)
        {
            var bookings = await _bookingService.GetBookingsByUser(userId);
            return bookings.Any() ? Ok(bookings) : BadRequest($"No bookings for user: {userId}");
        }
    }
}