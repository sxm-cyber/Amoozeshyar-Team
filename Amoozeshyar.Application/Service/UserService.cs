using Amoozeshyar.Application.Commands;
using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;

using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Domain.Models;
using Microsoft.AspNetCore.Identity;


namespace Amoozeshyar.Domain
    {
        public class UserService : IUserService
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly ITokenService _tokenService;
        private readonly IFileStorage _fileStorage;
        private readonly IRepository<Profile> _profileRepository;


        public UserService(UserManager<ApplicationUser> userManager, ITokenService tokenService , IFileStorage fileStorage, IRepository<Profile> profileRepository)
            {
                _userManager = userManager;
               _tokenService = tokenService;
            _fileStorage = fileStorage;
            _profileRepository = profileRepository;
           
                
            }
        public async Task<FullProfileDto> RegisterAsync(UserRegisterCommand command)
        {
            var user = new ApplicationUser(command.FullName, command.Email, Guid.NewGuid());
            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(i => i.Description)));


            var profile = new Profile(user.Id, $"{command.FullName}", user.Email, "/images/default-profile.png");

            if (command.FileStream != null && !string.IsNullOrWhiteSpace(command.FileName))
            {
                var path = await _fileStorage.SaveFileAsync(command.FileStream, command.FileName, "uploads");
                profile.SetProfilePicture(path);
            }

            await _profileRepository.AddAsync(profile);
            await _profileRepository.SaveChangesAsync();



            var roles = await _userManager.GetRolesAsync(user);
            return new FullProfileDto
            {
                FullName = profile.FullName,
                Email = profile.Email,
                PhoneNumber = profile.PhoneNumber,
                ProfilePictureUrl = profile.ProfilePictureUrl,
                UserName = user.UserName,
                Role = roles.FirstOrDefault() ?? "",
                Courses = new List<CourseDto>()
            };
        }



        public async Task<string> LoginAsync(UserLoginCommand command)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
                throw new Exception("User not found");

            var valid = await _userManager.CheckPasswordAsync(user, command.Pssword);
            if (!valid)
                throw new Exception("The password or email is incorrect.");

            return _tokenService.GenerateJwtToken(user);


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
