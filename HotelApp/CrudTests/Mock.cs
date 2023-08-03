using HotelApp.Data;
using HotelApp.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTests
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly HotelDbContext _context;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _context = new HotelDbContext(new DbContextOptionsBuilder<HotelDbContext>().UseSqlite(_connection).Options);

            _context.Database.EnsureCreated();  
        }

        protected async Task<Hotel> CreateAndSaveHotel()
        {
            Hotel hotel = new Hotel() {  city = "Amman Test", Country = "Jordan Test", Name = "regency dalas Test", Phone = 05469788, state = "Jordan Test", streetAddress = "#####" };
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();  
            return hotel;
        }
        protected async Task<Hotel> UpdateAndSaveHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }
        public void Dispose()
        {
            _context?.Dispose();

            _connection?.Dispose();
        }
    }
}
