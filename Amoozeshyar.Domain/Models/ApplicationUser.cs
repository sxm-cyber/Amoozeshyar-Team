using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using Amoozeshyar.Domain.Common;

namespace Amoozeshyar.Domain.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public DateTime? DateOfBirth { get; private set; }

        public string? Address { get; private set; }


		public ICollection<Enrollment>? Enrollments { get; private set; } = new List<Enrollment>();
		public ICollection<Enrollment> EnrollmentTeaching { get; set; } = new List<Enrollment>();


        public DateTime CreatedAt { get; private set; } = BaseEntity.GetPersianNow();
        public Guid CreatedBy { get; private set; }

        private ApplicationUser() { }

        public ApplicationUser(string firstName, string lastName, string email, Guid createdBy)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = email;
            CreatedBy = createdBy;
        }

       
        public void SetDateOfBirth(int year, int month, int day)
        {
            var pc = new PersianCalendar();
            DateOfBirth = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
    }
}
