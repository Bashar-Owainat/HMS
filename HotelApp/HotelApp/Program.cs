using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Models.Interfaces;
using HotelApp.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                
            })
 .AddEntityFrameworkStores<HotelDbContext>();

            builder.Services.AddTransient<IUser, IdentityUserService>();
            builder.Services.AddTransient<IHotel, HotelServices>();
            builder.Services.AddTransient<IRoom, RoomServices>();
            builder.Services.AddTransient<IAmenity, AmenityServices>();
            builder.Services.AddTransient<IHotelRoom, HotelRoomService>();

            //here add for hotelRoom

            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hotel API",
                    Description = "An ASP.NET Core Web API for managing Hotels"

                });
            });
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //    options.RoutePrefix = string.Empty;
            //});

            app.UseSwagger(aptions =>
            {
                aptions.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(aptions =>
            {
                aptions.SwaggerEndpoint("/api/v1/swagger.json", "School API");
                aptions.RoutePrefix = "docs";
            });


            app.MapGet("/", () => "Hello World!");

            app.MapControllers();

            app.Run();
        }
    }
}