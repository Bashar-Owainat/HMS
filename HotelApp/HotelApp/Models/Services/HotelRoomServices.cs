﻿using HotelApp.Data;
using HotelApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Models.Services
{
    public class HotelRoomServices : IHotelRoom
    {
        private readonly HotelDbContext _context;
        public HotelRoomServices(HotelDbContext context)
        {
            _context = context;
        }


        public async Task<HotelRoom> GetRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms.Include(hr => hr.Room).FirstOrDefaultAsync(hr => hr.RoomNumber == roomNumber && hr.HotelId == hotelId);
            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetRooms(int hotelId)
        {

            var rooms = await _context.HotelRooms.Where(hr => hr.HotelId == hotelId).Include(hr => hr.Room).ThenInclude(r => r.RoomAmenities).ToListAsync();
            return rooms;
        }



        public async Task<HotelRoom> UpdateRoom(int hotelId, int roomId, HotelRoom room)
        {
            _context.Entry<HotelRoom>(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task DeleteRoom(int hotelId, int roomId)
        {
            HotelRoom hotelRoom = await GetRoom(hotelId, roomId);
            _context.Entry<HotelRoom>(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }
        public async Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hotelRoom)
        {

            _context.Entry<HotelRoom>(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }



        public async Task RemoveRoomFromHotel(int roomId, int hotelId)
        {
            var room = await _context.HotelRooms.FirstOrDefaultAsync(rm => rm.HotelId == hotelId && rm.RoomId == roomId);
            _context.Entry<HotelRoom>(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }
    }
}
