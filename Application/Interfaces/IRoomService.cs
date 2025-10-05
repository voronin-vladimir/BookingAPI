using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRoomService
    {
        Task<Room> CreateRoom(Room room);
        Task<bool> DeleteRoom(int id);
        Task<Room?> GetRoom(int id);
        Task<IEnumerable<Room>> GetRooms();
    }
}