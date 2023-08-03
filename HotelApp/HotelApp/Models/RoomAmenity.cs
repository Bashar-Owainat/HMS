using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class RoomAmenity
    {
       
        public int AmenityId { get; set; }
       
        public int RoomId { get; set; }

        public Room? Room { get; set; }
        public Amenity? Amenity { get; set; }
    }
}
