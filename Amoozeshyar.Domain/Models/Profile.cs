using Amoozeshyar.Domain.Common;
using System;

namespace Amoozeshyar.Domain.Models
{
    public class Profile : BaseEntity
    {
        public Guid UserId { get; private set; }

        public string FullName { get; private set; }

        public string Email { get; private set; }

        public string? PhoneNumber { get; private set; }

        public string ProfilePictureUrl { get; private set; }

        public virtual ApplicationUser User { get; private set; }

        private Profile() { }

        public Profile(Guid userId, string fullName, string email, string profilePictureUrl)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            ProfilePictureUrl = profilePictureUrl;
        }

        public void UpdateProfile(string fullName, string email, string? phoneNumber = null)
        {
            FullName = fullName;
            Email = email;
            if (phoneNumber != null)
                PhoneNumber = phoneNumber;
        }

        public void SetProfilePicture(string url)
        {
            ProfilePictureUrl = url;
        }
    }
}
