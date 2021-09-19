using HotelManagementSystem.Core.Entities;
using HotelManagementSystem.Core.Repositories;
using HotelManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Service.Services
{
    public class BookingServce : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomService _roomService;
        private readonly IRoomRepository _roomRepository;

        public BookingServce(IBookingRepository bookingRepository, IRoomService roomService, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _roomService = roomService;
            _roomRepository = roomRepository;
        }
        public bool BookRoom(Customer customer, string roomId, int numberOfOccupants, DateTime checkInDate)
        {
            try
            {
                if (!_roomService.IsRoomAvailable(roomId))
                {
                    throw new Exception("Room Is not Available for booking");
                }

                var booking = new Booking(customer, _roomRepository.GetById(roomId));
                booking.NumberOfOccupants = numberOfOccupants;
                booking.CheckInDate = checkInDate;
                _bookingRepository.Add(booking);
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool CancelBooking(Customer customer, Room room, string bookingId)
        {
            try
            {
                var booking = _bookingRepository.GetById(bookingId);
                booking.IsActive = false;
                booking.IsCancelled = true;
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool CheckOut(string bookingId, string customerId, string roomId)
        {
            try
            {
                var booking = _bookingRepository.GetById(bookingId);
                if (booking != null)
                {
                    booking.IsActive = false;
                    booking.Room.LastBookedBy = customerId;
                    booking.DateCheckedOut = DateTime.Now;
                    booking.Room.IsOccupied = false;
                    _bookingRepository.Update(booking);
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
    }
}
