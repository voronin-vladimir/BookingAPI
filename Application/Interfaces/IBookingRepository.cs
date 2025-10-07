using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking?> BookRoom(Booking booking);
        Task<Booking?> GetBooking(int id);
        Task<IEnumerable<Booking>> GetBookingsByUser(string userId);
        Task<IEnumerable<Booking>> GetBookingsByRoom(int roomId);
    }
}