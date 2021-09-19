using HotelManagementSystem.Core.Entities;
using HotelManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Core.Services
{
    public interface IBookingService
    {
        bool BookRoom(Customer customer, string roomId, int numberOfOccupants, DateTime checkInDate);
        bool CancelBooking(Customer customer, Room room, string bookingId);
        bool CheckOut(string bookingId, string customerId, string roomId);

    }
}
