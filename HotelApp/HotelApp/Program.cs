using HotelApp.Data;
using HotelApp.Models.Interfaces;
using HotelApp.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services
               .AddDbContext<HotelDbContext>
               (opions => opions.UseSqlServer(ConnectionString));
            builder.Services.AddControllers();
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
     );
            builder.Services.AddTransient<IHotel, HotelServices>();
            builder.Services.AddTransient<IRoom, RoomServices>();
            builder.Services.AddTransient<IAmenity, AmenityServices>();
            //here add for hotelRoom

            var app = builder.Build();
            app.MapControllers();   
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}