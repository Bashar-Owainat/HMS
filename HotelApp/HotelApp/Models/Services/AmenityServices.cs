using HotelApp.Data;
using HotelApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Models.Services
{
    public class AmenityServices : IAmenity
    {
        private readonly HotelDbContext _context;

        public AmenityServices(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> CreateAmenity(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }
        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            return amenity;
        }


        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
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
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }


    }
}
