using HotelApp.Models.DTOs;

namespace HotelApp.Models.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> CreateAmenity(AmenityDTO amenity);
        Task<List<Amenity>> GetAmenities();

        Task<AmenityDTO> GetAmenity(int id);
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);

        Task DeleteAmenity(int id);

    }
}
