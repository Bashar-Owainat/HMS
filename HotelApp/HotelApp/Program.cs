using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Models.Interfaces;
using HotelApp.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

            string? ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            builder.Services.AddTransient<IHotel, HotelServices>();
            builder.Services.AddTransient<IRoom, RoomServices>();
            builder.Services.AddTransient<IAmenity, AmenityServices>();
            builder.Services.AddTransient<IGenericRepo<Amenity>, GenericRepo<Amenity>>();
            builder.Services.AddTransient<IHotelRoom, HotelRoomServices>();
            builder.Services.AddScoped<JwtTokenService>();
            builder.Services.AddTransient<IUser, IdentityUserService>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                
                options.TokenValidationParameters = JwtTokenService.GetValidationPerameters(builder.Configuration);
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
                options.AddPolicy("read", policy => policy.RequireClaim("permissions", "read"));
                options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
                options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));

            });
            builder.Services.AddAuthorization();
            

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

            app.UseCors("AllowAnyOrigin");
            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseSwagger(aptions =>
            {
                aptions.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(aptions =>
            {
                aptions.SwaggerEndpoint("/api/v1/swagger.json", "Hotels API");
                aptions.RoutePrefix = "docs";
            });


            app.MapGet("/index.html", () => "Hello World!");

            app.MapControllers();

            app.Run();
        }
    }
}