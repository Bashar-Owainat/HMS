using HotelApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace HotelApp.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDto> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDto> Authenticate(string username, string password);
        public Task<UserDto> GetUser(ClaimsPrincipal principal);
    }
}
