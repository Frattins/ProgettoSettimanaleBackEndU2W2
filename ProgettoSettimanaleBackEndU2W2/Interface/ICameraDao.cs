using System.Collections.Generic;
using ProgettoSettimanaleBackEndU2W2.Models;

namespace ProgettoSettimanaleBackEndU2W2.Interface
{
    public interface ICameraDao
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int id);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int id);
    }
}