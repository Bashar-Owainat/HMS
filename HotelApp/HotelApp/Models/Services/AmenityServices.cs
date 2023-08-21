using HotelApp.Data;
using HotelApp.Models.Interfaces;

namespace HotelApp.Models.Services
{
    public class AmenityServices : GenericRepo<Amenity>, IAmenity
    {
        public AmenityServices(HotelDbContext context) : base(context)
        {
        }
    }
}
