using HotelApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data
{
    public class HotelDbContext : IdentityDbContext<AppUser>
    {  
        public HotelDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RoomAmenity>().HasKey(r => new { r.AmenityId, r.RoomId });
            modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelId, hr.RoomId });

            modelBuilder.Entity<Hotel>().HasData(

                new Hotel() { Id = 1, city = "Amman", Country = "Jordan", Name = "regency dalas", Phone = 05469788, state = "Jordan", streetAddress = "#####" },
                new Hotel() { Id = 2, city = "Amman", Country = "Jordan", Name = "marriott", Phone = 05469788, state = "Jordan", streetAddress = "#####" },
                new Hotel() { Id = 3, city = "Amman", Country = "Jordan", Name = "grand haya", Phone = 05469788, state = "Jordan", streetAddress = "#####" });


            modelBuilder.Entity<Room>().HasData(


                  new Room() { Id = 1, Layout = 3, Name = "red" },
                  new Room() { Id = 2, Layout = 4, Name = "blue" },
                  new Room() { Id = 3, Layout = 5, Name = "green" }


                );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity() { Id = 1, Name = "AC" },
                new Amenity() { Id = 2, Name = "sauna" },
                new Amenity() { Id = 3, Name = "pool" }
                );
            modelBuilder.Entity<RoomAmenity>().HasData(
                new RoomAmenity() { AmenityId = 1, RoomId = 1 },
                new RoomAmenity() { AmenityId = 2, RoomId = 1 },
                new RoomAmenity() { AmenityId = 3, RoomId = 2 }
                );

            modelBuilder.Entity<HotelRoom>().HasData(
                new HotelRoom() { HotelId = 1, RoomId = 1, PetFriendly = true, RoomNumber = 111, Rate = 3 },
                new HotelRoom() { HotelId = 1, RoomId = 2, PetFriendly = false, RoomNumber = 222, Rate = 4 },
                new HotelRoom() { HotelId = 2, RoomId = 3, PetFriendly = true, RoomNumber = 333, Rate = 5 }

                );


            SeedRole(modelBuilder, "DistrictManager", "create", "read", "update", "delete");
            SeedRole(modelBuilder, "PropertyManager", "create", "read", "update");
            SeedRole(modelBuilder, "Agent", "create", "read", "update", "delete");
            SeedRole(modelBuilder, "Anonymous",  "read");
        }
        int nextId = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

           
            var roleClaims = permissions.Select(permission =>
              new IdentityRoleClaim<string>
              {
                  Id = nextId++,
                  RoleId = role.Id,
                  ClaimType = "permissions", 
                  ClaimValue = permission
              }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set;}
    }
}
