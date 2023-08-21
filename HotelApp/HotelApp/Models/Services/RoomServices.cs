using HotelApp.Data;
using HotelApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Models.Services
{
    public class RoomServices : GenericRepo<Room>,IRoom
    {
        public RoomServices(HotelDbContext context) : base(context)
        {
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity { AmenityId = amenityId, RoomId = roomId };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

       

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var roomAmenity = await _context.RoomAmenities.FirstOrDefaultAsync(rm => rm.RoomId == roomId && rm.AmenityId == amenityId);
            _context.Entry(roomAmenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

       
    }
}
