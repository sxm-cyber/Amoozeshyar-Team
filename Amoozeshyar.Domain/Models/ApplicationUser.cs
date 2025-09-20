using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using Amoozeshyar.Domain.Common;

namespace Amoozeshyar.Domain.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public string FullName { get; private set; }

        public DateTime? DateOfBirth { get; private set; }

        public string? Address { get; private set; }



        public ICollection<Enrollment>? Enrollments { get; private set; } = new List<Enrollment>();
		public ICollection<Enrollment> EnrollmentTeaching { get; set; } = new List<Enrollment>();


        public DateTime CreatedAt { get; private set; } = BaseEntity.GetPersianNow();
        public Guid CreatedBy { get; private set; }

        public Guid? ProfileId { get; private set; }
        public virtual Profile Profile { get; private set; }


        private ApplicationUser() { }


        public ApplicationUser(string fullName, string email, Guid createdBy)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            UserName = email;
            CreatedBy = createdBy;
        }


        public void UpdateFullName(string fullName)
        {
            FullName = fullName;
        }


        public void SetDateOfBirth(int year, int month, int day)
        {
            var pc = new PersianCalendar();
            DateOfBirth = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public void SetProfile(Profile profile)
        {
            Profile = profile ?? throw new ArgumentNullException(nameof(profile));
            ProfileId = profile.Id;
        }
    }
}
