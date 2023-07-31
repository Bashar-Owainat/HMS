namespace HotelApp.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> CreateRoom(string name, int layout);
        Task<List<Room>> GetRooms();

        Task<Room> GetRoom(int id);
        Task<Room> UpdateRoom(int id, Room room);

        Task DeleteRoom(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
