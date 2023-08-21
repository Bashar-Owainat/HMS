using HotelApp.Models.DTOs;

namespace HotelApp.Models.Interfaces
{
    public interface IRoom : IGenericRepo<Room>
    {
       

        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
