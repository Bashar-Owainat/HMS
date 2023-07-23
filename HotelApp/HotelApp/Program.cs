using HotelApp.Data;
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

            var app = builder.Build();
            app.MapControllers();   
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}