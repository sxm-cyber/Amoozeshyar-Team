using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);

            if (result.StartsWith("کاربر") || result.StartsWith("رمز"))
                return Unauthorized(result);

            return Ok(new { Token = result });
        }
        

        [HttpPost("Forgot-Password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordDto dto )
        {
            var token = await _userService .ForgotPasswordAsync(dto);
            return Ok(new {Token=token});

        }

        [HttpPost("Reset-Password")]
        [AllowAnonymous]
        public async Task<IActionResult>ResetPassword([FromBody] ResetPasswordDto dto)
        {

            await _userService.ResetPasswordAsync(dto.Email, dto.Token,dto.NewPassword);

            return Ok("Password Rest successfully ");


        }
    }
}
