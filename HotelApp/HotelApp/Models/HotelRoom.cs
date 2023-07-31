using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelApp.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public Room? Room { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
