using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Core.Entities
{
    public class Customer
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string Id { get { return InternalId.ToString(); } set { } }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
