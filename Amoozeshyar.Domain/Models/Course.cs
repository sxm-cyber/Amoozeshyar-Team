using System;
namespace Amoozeshyar.Domain.Models
{
    
    public class Course
	{

		public Guid Id { get; private set; } = Guid.NewGuid();

		public string Name { get; private set; } = string.Empty;

		public string Code { get; private set; } = string.Empty;

		public int Units { get; private set; }

        public string? Description { get; private set; }

		
		public ApplicationUser? Teacher { get; private set; }

		public ICollection<Enrollment>? Enrollments { get; private set; }


		private Course() {}

		public Course(string name , string code, int units , string? description = null )
		{
			Name = name;
			Code = code;
			Units = units;
			Description = description;
		}

		public void UpdateCourse(string name , string code , int units)
		{
			Name = name;
			Code = code;
			Units = units;
		}
		
	}
}

