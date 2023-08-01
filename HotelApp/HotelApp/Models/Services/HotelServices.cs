using HotelApp.Data;
using HotelApp.Models.DTOs;
using HotelApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Models.Services
{
    public class HotelServices :IHotel
    {
        private readonly HotelDbContext _context;

        public HotelServices(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;   

        }


        public async Task<Hotel> GetHotel(int id)
        {
            Hotel? hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Hotel>> GetHotels()
        {
           var Courses = await _context.Hotels.Include(h=> h.HotelRooms)
                                              .ThenInclude(hr=>hr.Room)
                                               .ToListAsync();
            return Courses; 
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
