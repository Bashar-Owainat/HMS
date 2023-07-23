using HotelApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Hotel>().HasData(
               
                 new Hotel() { Id = 16, city = "Amman", Country = "Jordan", Name = "regency dalas", Phone = 05469788, state = "Jordan", streetAddress = "#####" },
                 new Hotel() { Id = 7, city = "Amman", Country = "Jordan", Name = "marriott", Phone = 05469788, state = "Jordan", streetAddress = "#####" },
                 new Hotel() { Id = 8, city = "Amman", Country = "Jordan", Name = "grand haya", Phone = 05469788, state = "Jordan", streetAddress = "#####" });


            modelBuilder.Entity<Room>().HasData(
               
                
                  new Room() { Id = 16, Layout = 3, Name = "red" },
                  new Room() { Id = 7, Layout = 4, Name = "blue" },
                  new Room() { Id = 8, Layout = 5, Name = "green" }


                );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity() { Id = 1 , Name = "AC"},
                new Amenity() { Id = 2, Name = "swimming pool" }

                );
          
        }
       
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }




    }
}
