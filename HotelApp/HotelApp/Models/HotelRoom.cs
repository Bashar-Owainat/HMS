using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class HotelRoom
    {
        [Key]
        [Column(Order = 1)]
        public int hotelId { get; set; }
        public int roomNumber { get; set; }
        [Key]
        [Column(Order = 2)]
        public int roomId { get; set; }
        public int rate { get; set; }
        public bool petFriendly { get; set; }
    }
}
