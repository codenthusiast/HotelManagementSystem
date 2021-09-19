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

    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            try
            {
                _context.Customers.InsertOne(entity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Customer> entities)
        {
            try
            {
                _context.Customers.InsertMany(entities);
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
                    = _context.Customers.DeleteOne(
                        Builders<Customer>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                return _context.Customers.Find(_ => true).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Customer GetById(string id)
        {
            ObjectId internalId = GetInternalId(id);
            return _context.Customers
                            .Find(customer => customer.Id == id
                                    || customer.InternalId == internalId)
                            .FirstOrDefault();
        }

        public IEnumerable<Customer> GetByQuery(Expression<Func<Customer, bool>> expression)
        {
            return _context.Customers.Find(expression).ToList();
        }

        public bool Update(Customer entity)
        {
            try
            {
                ReplaceOneResult actionResult
                    = _context.Customers
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
