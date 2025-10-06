using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAll();
        Task<Room?> GetById(int id);
        Task<Room> Add(Room room);
        Task Delete(int id);
    }
}