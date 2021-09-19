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

    public class BookingRepository : IBookingRepository
    {
        private AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {

            _context = context;
        }


        public void Add(Booking entity)
        {
            try
            {
                _context.Bookings.InsertOne(entity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Booking> entities)
        {
            try
            {
                _context.Bookings.InsertMany(entities);
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
                    = _context.Bookings.DeleteOne(
                        Builders<Booking>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Booking> GetAll()
        {
            try
            {
                return _context.Bookings.Find(_ => true).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Booking GetById(string id)
        {
            ObjectId internalId = GetInternalId(id);
            return _context.Bookings
                            .Find(Booking => Booking.Id == id
                                    || Booking.InternalId == internalId)
                            .FirstOrDefault();
        }

        public IEnumerable<Booking> GetByQuery(Expression<Func<Booking, bool>> expression)
        {
            return _context.Bookings.Find(expression).ToList();
        }

        public bool Update(Booking entity)
        {
            try
            {
                ReplaceOneResult actionResult
                    = _context.Bookings
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
