using System;
using System.Linq;
using System.Threading.Tasks;
using Amoozeshyar.Application.Commands;
using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Amoozeshyar.Application.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<Enrollment> _enrollmentRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileStorage _fileStorage;

        public ProfileService(
            IRepository<Profile> profileRepository,
            IRepository<Enrollment> enrollmentRepository,
            UserManager<ApplicationUser> userManager,
            IFileStorage fileStorage)
        {
            _profileRepository = profileRepository;
            _enrollmentRepository = enrollmentRepository;
            _userManager = userManager;
            _fileStorage = fileStorage;
        }

        public async Task<FullProfileDto> CreateProfileAsync(UserRegisterCommand command)
        {
            var user = new ApplicationUser(command.FullName, command.Email, Guid.NewGuid())
            {
                UserName = command.Email,
                PhoneNumber = command.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(",", result.Errors.Select(i => i.Description)));

            if(!string.IsNullOrWhiteSpace(command.Role))
            {
                var roleResult = await _userManager.AddToRoleAsync(user, command.Role);
                if (!roleResult.Succeeded)
                    throw new Exception(string.Join(",", roleResult.Errors.Select(i => i.Description)));
            }

            string profilePicture = "/images/default-profile.png";

            if (command.File != null && command.File.Length > 0)
                profilePicture = await _fileStorage.SaveFileAsync(command.File, "uploads");

            var profile = new Profile(user.Id, command.FullName, command.Email, profilePicture);

            if (!string.IsNullOrWhiteSpace(command.PhoneNumber))
                profile.UpdateProfile(command.FullName, command.Email, command.PhoneNumber);

            await _profileRepository.AddAsync(profile);
            await _profileRepository.SaveChangesAsync();

            user.SetProfile(profile);

            await _userManager.UpdateAsync(user);

            var roles = await _userManager.GetRolesAsync(user);

            return new FullProfileDto
            {
                FullName = profile.FullName,
                Email = profile.Email,
                PhoneNumber = profile.PhoneNumber,
                ProfilePictureUrl = profile.ProfilePictureUrl,
                UserName = user.UserName,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault() ?? "",
                Courses = new List<CourseDto>()
            };
        }


        public async Task<FullProfileDto> GetFullProfileAsync(Guid userId)
        {
            var profiles = await _profileRepository.GetAllAsync();
            var userProfile = profiles.FirstOrDefault(p => p.UserId == userId);

            if (userProfile == null)
                return null;

            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await _userManager.GetRolesAsync(user);

            var enrollments = (await _enrollmentRepository.GetAllAsync()).Where(e => e.StudentId == userId).ToList();

            var courseDtos = enrollments.Select(e => new CourseDto
            {
                CourseName = e.Course.Name,
                CourseCode = e.Course.Code,
                TeacherName = e.Teacher.FullName
            }).ToList();

            return new FullProfileDto
            {
                FullName = userProfile.FullName,
                Email = userProfile.Email,
                PhoneNumber = userProfile.PhoneNumber,
                ProfilePictureUrl = userProfile.ProfilePictureUrl,
                UserName = user.UserName,
                Role = roles.FirstOrDefault() ?? "",
                Courses = courseDtos
            };
        }
    }
}
