using Amoozeshyar.Application.Commands;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



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

            public async Task RegisterAsync(UserRegisterCommand command)
            {
                var user = new ApplicationUser(command.FirstName, command.LastName, command.Email);

                var result = await _userManager.CreateAsync(user, command.Password);

                if (result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(i => i.Description)));
            }

            public async Task<string> LoginAsync(UserLoginCommand command)
            {
                var user = await _userManager.FindByEmailAsync(command.Email);
                if (user == null)
                    throw new Exception("User not found");

                var valid = await _userManager.CheckPasswordAsync(user, command.Pssword);
                if (!valid)
                    throw new Exception("The password or email is incorrect.");

            
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                 }),
                    Expires = DateTime.UtcNow.AddHours(5),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            public async Task<string> ForgotPasswordAsync(ForgotPasswordCommand command)
            {
                var user = await _userManager.FindByEmailAsync(command.Email);
                if (user == null)
                    throw new Exception("User not found");

            
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

  
                return token; 

            }

            public async Task ResetPasswordAsync(string email, string token, string newPassword)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    throw new Exception("User not found");

                var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
                }

            }
    }}
