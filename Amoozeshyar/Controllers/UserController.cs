using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        // POST: api/users/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            try
            {
                await _userService.RegisterAsync(dto);
                return Ok("ثبت‌نام با موفقیت انجام شد.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);

            if (result.StartsWith("کاربر") || result.StartsWith("رمز"))
                return Unauthorized(result);

            return Ok(new { Token = result });
        }
    }
}
