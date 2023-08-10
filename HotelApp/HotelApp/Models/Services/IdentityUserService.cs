using HotelApp.Models.DTOs;
using HotelApp.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace HotelApp.Models.Services
{
    public class IdentityUserService : IUser
    {
        private UserManager<AppUser> _userManager;
        private JwtTokenService _tokenService;
        public IdentityUserService(UserManager<AppUser> userManager, JwtTokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async  Task<UserDto> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool IsValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if(IsValidPassword) 
            {
                return new UserDto
                { Id = user.Id,
                    Username = user.UserName,
                    Token = await _tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
                };
            }

            return null;
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);

            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await _tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
            };
        }
        public async Task<UserDto> Register(RegisterUserDTO registerUser, ModelStateDictionary modelState)
        {
            var user = new AppUser
            {
                UserName = registerUser.Username,
                Email = registerUser.Email,
                PhoneNumber = registerUser.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, registerUser.Roles);
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await _tokenService.GetToken(user, System.TimeSpan.FromMinutes(5)),
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(registerUser.Password) :
                               error.Code.Contains("Email") ? nameof(registerUser.Email) :
                               error.Code.Contains("Username") ? nameof(registerUser.Username) :
                                "";

                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }
    }
}
