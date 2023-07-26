namespace HotelApp.Models.Interfaces
{
    public interface IHotel
    {

        Task<Hotel> CreateHotel(Hotel hotel);
        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotel(int id);
        Task<Hotel> UpdateHotel(int id, Hotel hotel);

        Task DeleteHotel(int id);

    }
}
