using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Core.Entities
{
    public class Booking
    {
        public Booking(Customer customer, Room room)
        {
            DateBooked = DateTime.Now;
            ExpectedCheckoutDate = CheckInDate.AddDays(DurationInDays);
            Customer = customer;
            Room = room;

        }

        [BsonId]
        public ObjectId InternalId { get; set; }
        public string Id { get { return InternalId.ToString(); } set { } }
        [BsonDateTimeOptions]
        public DateTime DateBooked { get; set; }
        [BsonDateTimeOptions]
        public DateTime CheckInDate { get; set; }
        [BsonDateTimeOptions]
        public DateTime ExpectedCheckoutDate { get; set; }
        [BsonDateTimeOptions]
        public DateTime DateCheckedOut { get; set; }
        public int DurationInDays { get; set; }
        public bool IsActive { get; set; }
        public bool IsCancelled { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public int NumberOfOccupants { get; set; }
    }
}
