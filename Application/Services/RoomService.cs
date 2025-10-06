using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository) => _roomRepository = roomRepository;

        public async Task<Room> CreateRoom(Room room) => await _roomRepository.Add(room);

        public async Task<bool> DeleteRoom(int id)
        {
            try
            {
                await _roomRepository.Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<Room?> GetRoom(int id) => await _roomRepository.GetById(id);

        public async Task<IEnumerable<Room>> GetRooms() => await _roomRepository.GetAll();
    }
}