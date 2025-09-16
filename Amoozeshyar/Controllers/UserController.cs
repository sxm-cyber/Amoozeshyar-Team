using Amoozeshyar.Application.Commands;
using Amoozeshyar.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amoozeshyar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterCommand command)
        {
            try
            {
                await _userService.RegisterAsync(command);
                return Ok("Register Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordCommand command)
        {
            var token = await _userService .ForgotPasswordAsync(command);
            return Ok(new {Token=token});

        }

        [HttpPost("Reset-Password")]
        [AllowAnonymous]
        public async Task<IActionResult>ResetPassword([FromBody] ResetPasswordCommand command)
        {

            await _userService.ResetPasswordAsync(command.Email, command.Token,command.NewPassword);

            return Ok("Password Rest successfully ");


        }
    }
}
