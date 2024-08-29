using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Modules;
using Tunify_Platform.Modules.DTO;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountService;
        private readonly IUser _userService;
        private UserManager<ApplicationUser> _userManager;



        public AccountController(IAccount accountService, IUser userService, UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerdUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = await _accountService.Register(registerdUserDto, ModelState);

            if (userDto == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(userDto);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = await _accountService.UserAuthentication(loginDto.Username, loginDto.Password);

            if (userDto == null)
            {
                return Unauthorized("Invalid login attempt");
            }

            var user = await _userManager.FindByNameAsync(loginDto.Username);
            var roles = await _userManager.GetRolesAsync(user);
            var token = await _accountService.GenerateJwtToken(user, roles);

            userDto.Token = token;
            userDto.Roles = roles;

            return Ok(userDto);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return Ok("Logout successful");
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("AdminPlaylist")]
        public async Task<IActionResult> SomeAdminAction()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}