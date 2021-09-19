using HotelManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Core.Services
{
    public interface IRoomService
    {
        IEnumerable<RoomModel> GetAllRooms();
        RoomModel CreateRoom(RoomModel room);
        RoomModel GetRoomById(string id);
        IEnumerable<RoomModel> GetRoomsByType(string roomType);
        IEnumerable<RoomModel> GetUnoccupiedRooms();
        IEnumerable<RoomModel> GetOccupiedRooms();
        IEnumerable<RoomModel> GetRoomBookingHistory(int roomId);
        bool IsRoomAvailable(string roomId);
    }
}
