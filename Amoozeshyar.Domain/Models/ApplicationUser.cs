using System;
using Microsoft.AspNetCore.Identity;

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

        private ApplicationUser() { }

		public ApplicationUser(string firstName , string lastName , string email)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			UserName = email;
			
		}

	}
}

