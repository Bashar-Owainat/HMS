using HotelApp.Data;
using HotelApp.Migrations;
using HotelApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HotelApp.Models.Services
{
    public class HotelRoomService : IHotelRoom
    {
        private readonly HotelDbContext _context;
        public HotelRoomService(HotelDbContext context)
        {
            _context= context;
        }


        public async Task<HotelRoom> GetRoom(int hotelId, int roomId )
        {
            var hotelRoom = await _context.HotelRooms.Include(hr=> hr.Room).FirstOrDefaultAsync(hr=> hr.RoomId== roomId && hr.HotelId == hotelId);
            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetRooms(int hotelId)
        {
            //var rooms = await _context.HotelRooms.Where(hr => hr.HotelId == hotelId).ToListAsync();
            var rooms = await _context.HotelRooms.ToListAsync();
            return rooms;
        }
      


        public async Task<HotelRoom> UpdateRoom(int hotelId, int roomId, HotelRoom room)
        {
            HotelRoom hotelRoom = await GetRoom(hotelId, roomId);
            _context.Entry(hotelRoom).State= EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
        public async Task DeleteRoom(int hotelId, int roomId)
        {
            HotelRoom hotelRoom = await GetRoom(hotelId, roomId);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }
        public async Task<HotelRoom> AddRoomToHotel(int roomId, int hotelId)
        {
            var room = await _context.HotelRooms.FirstOrDefaultAsync(rm => rm.HotelId == hotelId && rm.RoomId == roomId);
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }


        public async Task RemoveRoomFromHotel(int roomId, int hotelId)
        {
            var room = await _context.HotelRooms.FirstOrDefaultAsync(rm => rm.HotelId == hotelId && rm.RoomId == roomId);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            
        }
    }
}
