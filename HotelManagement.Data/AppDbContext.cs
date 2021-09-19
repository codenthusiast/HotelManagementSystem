using HotelManagementSystem.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace HotelManagement.Data
{
    public class AppDbContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration.GetSection("MongoConnection:ConnectionString").Value);
            if (client != null)
                _database = client.GetDatabase(_configuration.GetSection("MongoConnection:Database").Value);
        }

        public IMongoCollection<Room> Rooms
        {
            get
            {
                return _database.GetCollection<Room>("Room");
            }
        }

        public IMongoCollection<Customer> Customers
        {
            get
            {
                return _database.GetCollection<Customer>("Customer");
            }
        }

        public IMongoCollection<Booking> Bookings
        {
            get
            {
                return _database.GetCollection<Booking>("Booking");
            }
        }
    }

}
