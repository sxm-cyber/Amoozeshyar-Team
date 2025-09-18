using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshyar.Domain.Common;

namespace Amoozeshyar.Domain.Models
{
    public class Profile : BaseEntity
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public string FullName { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public string ProfilePictureUrl { get; private set; }

        public Profile(Guid userId, string fullName, string email, string profilePictureUrl)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            FullName = fullName;
            Email = email;
            ProfilePictureUrl = profilePictureUrl;
        }

        public void UpdateProfile(string fullName, string email, string phoneNumber)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void SetProfilePicture(string url)
        {
            ProfilePictureUrl = url;
        }
    }

}
