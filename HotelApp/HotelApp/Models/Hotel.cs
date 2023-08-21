namespace HotelApp.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? streetAddress { get; set; }

        public string ?city { get; set; }    


        public string? state { get; set; }
        public string? Country { get; set; }
        public int Phone { get; set; }

        public List<HotelRoom>? HotelRooms { get; set; }
    }
}
