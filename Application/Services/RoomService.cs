using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class RoomService : IRoomService
    {
        public Task<Room> CreateRoom(Room room) => throw new System.NotImplementedException();

        public Task<bool> DeleteRoom(int id) => throw new System.NotImplementedException();

        public Task<Room?> GetRoom(int id) => throw new System.NotImplementedException();

        public Task<IEnumerable<Room>> GetRooms() => throw new System.NotImplementedException();
    }
}