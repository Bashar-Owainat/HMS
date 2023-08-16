using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Models.Interfaces;
using HotelApp.Models.DTOs;
using HotelApp.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

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
        public async Task<List<Room>> GetRooms()
        {
          var rooms = await _room.GetAll();
            return rooms;
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            Room room = await _room.GetById(id);

            RoomDTO? roomDTO = new RoomDTO
            {

                ID = room.Id,
                Name = room.Name,
                Layout = room.Layout,
               
            };
            return roomDTO;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            Room updated = await _room.Update(id, room);
            return Ok(updated);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await _room.Insert(room);
            return Ok();
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _room.Delete(id);

            return NoContent();
        }

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
