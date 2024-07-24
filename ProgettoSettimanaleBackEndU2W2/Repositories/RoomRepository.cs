using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgettoSettimanaleBackEndU2W2.Data;
using ProgettoSettimanaleBackEndU2W2.Interfaces;
using ProgettoSettimanaleBackEndU2W2.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgettoSettimanaleBackEndU2W2.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context;

        public RoomRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
