using HotelApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelApp.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDto> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDto> Authenticate(string username, string password);
    }
}
