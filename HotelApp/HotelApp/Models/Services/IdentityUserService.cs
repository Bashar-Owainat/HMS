using HotelApp.Models.DTOs;
using HotelApp.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelApp.Models.Services
{
    public class IdentityUserService : IUser
    {
        private UserManager<AppUser> _userManager;

        public IdentityUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async  Task<UserDto> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool IsValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if(IsValidPassword) 
            {
                return new UserDto { Id = user.Id, Username = user.UserName };
            }

            return null;
        }

        public async Task<UserDto> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            var user = new AppUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, data.Password);

            if(result.Succeeded)
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(data.Password) :
                               error.Code.Contains("Email") ? nameof(data.Email) :
                               error.Code.Contains("Username") ? nameof(data.Username) :
                                "";

                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }
    }
}
