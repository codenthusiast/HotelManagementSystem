using HotelManagementSystem.Core.Entities;
using HotelManagementSystem.Core.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelManagement.Data.Repositories
{

    public class RoomRepository : IRoomRepository
    {
        private AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }


        public void Add(Room entity)
        {
            try
            {
                _context.Rooms.InsertOne(entity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Room> entities)
        {
            try
            {
                _context.Rooms.InsertMany(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                DeleteResult actionResult
                    = _context.Rooms.DeleteOne(
                        Builders<Room>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Room> GetAll()
        {
            try
            {
                return _context.Rooms.Find(_ => true).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Room GetById(string id)
        {
            ObjectId internalId = GetInternalId(id);
            return _context.Rooms
                            .Find(Room => Room.Id == id
                                    || Room.InternalId == internalId)
                            .FirstOrDefault();
        }

        public IEnumerable<Room> GetByQuery(Expression<Func<Room, bool>> expression)
        {
            return _context.Rooms.Find(expression).ToList();
        }

        public bool Update(Room entity)
        {
            try
            {
                ReplaceOneResult actionResult
                    = _context.Rooms
                                    .ReplaceOne(n => n.Id.Equals(entity.Id)
                                            , entity
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

    }
}
