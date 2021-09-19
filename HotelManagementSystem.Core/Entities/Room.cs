using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Core.Entities
{
    public class Room
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string Id { get { return InternalId.ToString(); } set { } }
        public string Name { get; set; }
        public string Floor { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        [BsonDateTimeOptions]
        public DateTime LastBookedDate { get; set; }
        public string LastBookedBy { get; set; }
        public string RoomtType { get; set; }
        public string Description { get; set; }
        public bool IsOccupied { get; set; }
        public string ImageUrl { get; set; }
    }
}
