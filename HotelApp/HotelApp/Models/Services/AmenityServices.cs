using HotelApp.Data;
using HotelApp.Models.DTOs;
using HotelApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Models.Services
{
    public class AmenityServices : IAmenity
    {
        private readonly HotelDbContext _context;
        private IRoom _room;
        public AmenityServices(HotelDbContext context, IRoom room)
        {
            _context = context;
            _room = room;
        }
        public async Task<Amenity> CreateAmenity(AmenityDTO amenity)
        {
            Amenity newAmenity = new Amenity { Name = amenity.Name };
            _context.Entry(newAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return newAmenity;
        }
        public async Task<AmenityDTO> GetAmenity(int id)
        {
            Amenity? amenity = await _context.Amenities.FirstOrDefaultAsync(a => a.Id == id);
            AmenityDTO amenityDTO = new AmenityDTO { ID = amenity.Id, Name = amenity.Name};
            return amenityDTO;
        }


        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.Include(rm => rm.RoomAmenities).ToListAsync();
            return amenities;
        }


        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (amenity);
        }
        public async Task DeleteAmenity(int id)
        {
            AmenityDTO amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }


    }
}
