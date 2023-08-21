using HotelApp.Data;
using HotelApp.Models.Interfaces;

namespace HotelApp.Models.Services
{
    public class HotelServices : GenericRepo<Hotel>, IHotel
    {
        public HotelServices(HotelDbContext context) : base(context)
        {
        }
    }
}
