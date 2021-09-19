using HotelManagementSystem.Core.Entities;
using HotelManagementSystem.Core.Models;
using HotelManagementSystem.Core.Repositories;
using HotelManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public RoomModel GetRoomById(string id)
        {
            var room = _roomRepository.GetById(id);
            return new RoomModel
            {
                Id = room.Id,
                Description = room.Description,
                Name = room.Name,
                Price = room.Price,
                RoomtType = room.RoomtType
            };
        }

        public RoomModel CreateRoom(RoomModel model)
        {
            try
            {
                var room = new Room()
                {
                    Id = model.Id,
                    Description = model.Description,
                    Floor = model.Floor,
                    IsActive = model.IsActive,
                    Name = model.Name,
                    RoomtType = model.RoomtType,
                    Price = model.Price
                };

                _roomRepository.Add(room);
                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<RoomModel> GetAllRooms()
        {
            var allRooms = _roomRepository.GetAll();
            var rooms = allRooms.Select(r => new RoomModel
            {
                Description = r.Description,
                Floor = r.Floor,
                IsActive = r.IsActive,
                Id = r.Id,
                Name = r.Name,
                Price = r.Price,
                RoomtType = r.RoomtType
            });

            return rooms;
        }

        public IEnumerable<RoomModel> GetOccupiedRooms()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomModel> GetRoomBookingHistory(int roomId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomModel> GetRoomsByType(string roomType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomModel> GetUnoccupiedRooms()
        {
            throw new NotImplementedException();
        }

        public bool IsRoomAvailable(string roomId)
        {
            try
            {
                var room = _roomRepository.GetById(roomId);
                return room.IsActive && !room.IsOccupied;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
