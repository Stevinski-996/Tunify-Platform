using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Tunify_Platform.Modules;
using Tunify_Platform.Modules.DTO;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    
    public class IdentityAccountService : IAccount
    
    {
        private JwtTokenServices _jwtTokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityAccountService(JwtTokenServices jwtTokenService,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService ;
        }

        public async Task<UserDTO> Register(RegisterDTO registerdUserDto, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerdUserDto.UserName,
                Email = registerdUserDto.Email,

            };

            var result = await _userManager.CreateAsync(user, registerdUserDto.Password);

            if (result.Succeeded)
            {
                return new UserDTO()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerdUserDto) :
                                error.Code.Contains("Email") ? nameof(registerdUserDto) :
                                error.Code.Contains("Username") ? nameof(registerdUserDto) : "";

                modelState.AddModelError(errorCode, error.Description);
            }

            return null;
        }

        // login
        public async Task<UserDTO> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new UserDTO()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            return null;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<string> GenerateJwtToken(ApplicationUser user, IList<string> roles)
        {
            return await _jwtTokenService.GenerateToken(user, TimeSpan.FromHours(4));
        }
    }
}
