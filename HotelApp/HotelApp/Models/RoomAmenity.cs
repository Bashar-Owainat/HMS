using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class RoomAmenity
    {
        [Key]
        public int AmenityId { get; set; }
        [Key]
        public int RoomId { get; set; }

        public Room Room { get; set; }
        public List<Amenity> Amenities { get; set; }
    }
}
