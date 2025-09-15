using System;
using Microsoft.AspNetCore.Identity;

namespace Amoozeshyar.Domain.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; private set; } = string.Empty;

		public string LastName { get; private set; } = string.Empty;

		public DateTime? DateOfBirth { get; private set; }

		public string? Address { get; private set; }

		//public string Role { get; private set; } = "Student";

		public ICollection<Course>? CoursesTeaching { get; private set; }
		public ICollection<Enrollment>? Enrollments { get; private set; }

		private ApplicationUser() { }

		public ApplicationUser(string firstName , string lastName , string email/* , string role*/)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			UserName = email;
			//Role = role;
		}

	}
}

