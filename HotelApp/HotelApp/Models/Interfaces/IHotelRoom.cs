using HotelApp.Migrations;

namespace HotelApp.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> GetRoom(int hotelId, int roomNumber);
        Task<List<HotelRoom>> GetRooms(int hotelId);

        Task<HotelRoom> UpdateRoom(int hotelId, int roomId, HotelRoom room);
        Task DeleteRoom(int hotelId, int roomId);
        Task<HotelRoom> AddRoomToHotel(int hotelId,HotelRoom hotelRoom);
        Task RemoveRoomFromHotel(int roomId, int hotelId);

    }
}
