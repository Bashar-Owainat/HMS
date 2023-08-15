using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Models.Interfaces;
using HotelApp.Models.DTOs;
using HotelApp.Migrations;

namespace HotelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IGenericRepo<Room> _room;
        public RoomsController(IGenericRepo<Room> room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<Task<IEnumerable<Room>>> GetRooms()
        {
            var rooms =  _room.GetAll();
            return rooms;
           
        }

        //// GET: api/Rooms/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        //{
        //    RoomDTO room = await _room.GetRoom(id); 
        //    return room;
        //}

        //// PUT: api/Rooms/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRoom(int id, Room room)
        //{
        //    Room updated = await _room.UpdateRoom(id, room);   
        //    return Ok(updated);
        //}

        //// POST: api/Rooms
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("{name}/rooms/{layout}")]
        //public async Task<ActionResult<Room>> PostRoom(string name, int layout)
        //{
        //    await _room.CreateRoom( name,  layout);
        //    return Ok();
        //}

        //// DELETE: api/Rooms/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRoom(int id)
        //{
        //   await _room.DeleteRoom(id);

        //    return NoContent();
        //}

        //[HttpPost]
        //[Route("{roomId}/Amenity/{amenityId}")]
        //public async Task<ActionResult> PostAmenityIntoRoom(int roomId, int amenityId)
        //{
        //  await  _room.AddAmenityToRoom(roomId, amenityId);
        //    return Ok();
        //}

        //[HttpDelete]
        //[Route("{roomId}/Amenity/{amenityId}")]
        //public async Task<ActionResult> DeleteAmentityFromRoom(int roomId, int amenityId)
        //{
        //   await  _room.RemoveAmentityFromRoom(roomId, amenityId);
        //    return NoContent();
        //}
    }
}
