using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Core.Models
{
    public class RoomModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string RoomtType { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
