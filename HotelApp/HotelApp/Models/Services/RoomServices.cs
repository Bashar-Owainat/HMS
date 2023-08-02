using HotelApp.Data;
using HotelApp.Models.DTOs;
using HotelApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Models.Services
{
    public class RoomServices : IRoom
    {
        private readonly HotelDbContext _context;
       
        public RoomServices(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Room> CreateRoom(string name, int layout)
        {
            Room newRoom = new Room { Layout = layout , Name = name};
            _context.Entry<Room>(newRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newRoom;
        }


        public async Task<RoomDTO> GetRoom(int id)
        {
            Room? room = await _context.Rooms.Include(rm => rm.RoomAmenities).ThenInclude(X => X.Amenity1).FirstOrDefaultAsync(r => r.Id == id);

            //RoomDTO? roomDTO = new RoomDTO
            //{

            //    ID = room.Id,
            //    Name = room.Name,
            //    Layout = room.Layout,
            //    Amenities = room.RoomAmenities.Select(rm => new AmenityDTO
            //    {
            //        ID = rm.AmenityId,
            //        Name = rm.Amenity.Name
            //    }).ToList()
            //};
       
            RoomDTO? roomDTO = new RoomDTO
            {

                ID = room.Id,
                Name = room.Name,
                Layout = room.Layout,
                Amenities = room.RoomAmenities.Select(rm => new AmenityDTO
                {
                        ID = rm.AmenityId,
                    Name = rm.Amenity1?.Name

                }).ToList()
                };


            return roomDTO;

            //Room room = await _context.Rooms.Include(rm => rm.RoomAmenities).FirstOrDefaultAsync(r => r.Id == id);
            //return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.Include(rm => rm.RoomAmenities).ToListAsync();
            return rooms;
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task DeleteRoom(int id)
        {
            RoomDTO room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity { AmenityId = amenityId, RoomId= roomId }; 
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var roomAmenity = await _context.RoomAmenities.FirstOrDefaultAsync(rm => rm.RoomId == roomId && rm.AmenityId == amenityId);
            _context.Entry(roomAmenity).State= EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
