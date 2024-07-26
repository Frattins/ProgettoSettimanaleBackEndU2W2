using System.Collections.Generic;
using ProgettoSettimanaleBackEndU2W2.Models;
using ProgettoSettimanaleBackEndU2W2.Interface;

namespace ProgettoSettimanaleBackEndU2W2.DAO
{
    public class CameraDao : ICameraDao
    {
        private readonly List<Room> _rooms = new List<Room>
        {
            new Room { RoomID = 1, RoomNumber = 101, Description = "Single Room", Type = "Single" },
            new Room { RoomID = 2, RoomNumber = 102, Description = "Double Room", Type = "Double" }
        };

        public IEnumerable<Room> GetAllRooms()
        {
            return _rooms;
        }

        public Room GetRoomById(int id)
        {
            return _rooms.Find(r => r.RoomID == id);
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public void UpdateRoom(Room room)
        {
            var existingRoom = GetRoomById(room.RoomID);
            if (existingRoom != null)
            {
                existingRoom.RoomNumber = room.RoomNumber;
                existingRoom.Description = room.Description;
                existingRoom.Type = room.Type;
            }
        }

        public void DeleteRoom(int id)
        {
            var room = GetRoomById(id);
            if (room != null)
            {
                _rooms.Remove(room);
            }
        }
    }
}
