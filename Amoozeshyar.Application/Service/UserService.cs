using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshyar.Domain
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public UserService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _config = config;
        }

        public async Task RegisterAsync(UserRegisterDto dto)
        {
            var user = new ApplicationUser(dto.FirstName, dto.LastName, dto.Email, dto.Role);

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(i => i.Description)));
        }

        public async Task<string> LoginAsync(UserLoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null)
                return "کاربر یافت نشد.";

            var valid = await _userManager.CheckPasswordAsync(user, dto.Pssword);

            if (!valid)
                return ".رمز عبور یا نام کاربری اشتباه است";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"] ?? "SecretKey123");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
