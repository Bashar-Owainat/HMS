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

namespace HotelApp.Controllers
{
    [Route("api/Hotels")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms
        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {
            var rooms = await _hotelRoom.GetRooms(hotelId);
            return rooms;
        }

        // GET: api/HotelRooms/5
        [HttpGet("{hotelId}/Rooms/{roomId}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomId)
        {
            HotelRoom hotelRoom = await _hotelRoom.GetRoom(hotelId, roomId); 
            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomId, HotelRoom room)
        {
           HotelRoom updatedRoom = await  _hotelRoom.UpdateRoom(hotelId, roomId, room);
            return Ok(updatedRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>>  PostRoomIntoHotel(int RoomId, int HotelId)
        {
            HotelRoom room = await _hotelRoom.AddRoomToHotel(RoomId, HotelId);
            return room;
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> DeleteRoomFromHotel(int hotelId, int roomId)
        {
            await _hotelRoom.DeleteRoom(hotelId, roomId);

            return NoContent();
        }

       
    }
}
