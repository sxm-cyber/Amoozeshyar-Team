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

		public string Semester { get; private set; } = "Fall";

		public int MaxStudents { get; private set; } = 30;

		public string TeacherId { get; private set; } = string.Empty;

		public ApplicationUser? Teacher { get; private set; }

		public ICollection<Enrollment>? Enrollments { get; private set; }


		private Course() {}

		public Course(string name , string code, int units , string semester , int maxStud , string teacherId , string? description = null )
		{
			Name = name;
			Code = code;
			Units = units;
			Semester = semester;
			MaxStudents = maxStud;
			TeacherId = teacherId;
			Description = description;
		}
		
	}
}

