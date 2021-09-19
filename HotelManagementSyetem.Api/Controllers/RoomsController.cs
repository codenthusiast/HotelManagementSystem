using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementSystem.Core.Models;
using HotelManagementSystem.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSyetem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<RoomModel> Get()
        {
            return _roomService.GetAllRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            return Ok(_roomService.GetRoomById(id));
        }

        // POST: api/Rooms
        [HttpPost]
        public void Post([FromBody] RoomModel model)
        {
            _roomService.CreateRoom(model);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
