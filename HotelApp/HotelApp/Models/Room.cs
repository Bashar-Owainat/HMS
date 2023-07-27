using System.Reflection.Metadata.Ecma335;

namespace HotelApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Layout { get; set; }

       public List<RoomAmenity> RoomAmenities { get; set; }

    }
}
