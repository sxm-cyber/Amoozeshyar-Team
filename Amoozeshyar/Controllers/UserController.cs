using Amoozeshyar.Application.Commands;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amoozeshyar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;


        public UserController(IUserService userService, IProfileService profileService)
        {
            _userService = userService;
            _profileService = profileService;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] UserRegisterCommand command)
        {


            
            

            var profile = await _profileService.CreateProfileAsync(command);
            return Ok(profile);
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginCommand command)
        {
            var result = await _userService.LoginAsync(command);

            if (result.StartsWith("کاربر") || result.StartsWith("رمز"))
                return Unauthorized(result);

            return Ok(new { Token = result });
        }


        [HttpPost("Forgot-Password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        {
            var token = await _userService.ForgotPasswordAsync(command);
            return Ok(new { Token = token });

        }

        [HttpPost("Reset-Password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {

            //await _userService.ResetPasswordAsync(command.Email, command.Token, command.NewPassword);

            return Ok("Password Rest successfully ");

        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = Guid.Parse(User.FindFirst("sub")?.Value!);
            var profile = await _profileService.GetFullProfileAsync(userId);
            if (profile == null)
                return NotFound("Profile not found");

            return Ok(profile);
        }
    }
}
