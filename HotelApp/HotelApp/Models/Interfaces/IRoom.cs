using HotelApp.Models.DTOs;

namespace HotelApp.Models.Interfaces
{
    public interface IRoom : IGenericRepo<Room>
    {
        //Task<Room> CreateRoom(Room room);
        //Task<List<Room>> GetRooms();

        //Task<RoomDTO> GetRoom(int id);
        //Task<Room> UpdateRoom(int id, Room room);

        //Task DeleteRoom(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
