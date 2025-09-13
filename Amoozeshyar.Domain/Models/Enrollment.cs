using System;
namespace Amoozeshyar.Domain.Models
{
	public class Enrollment
	{
		public Guid Id { get; private set; } = Guid.NewGuid();


		public string StudentId { get; private set; } = string.Empty;
		public ApplicationUser? Student { get; private set; }


        public Guid CourseId { get; private set; }
        public Course? Course { get; private set; }


		public double? Grade { get; private set; }

		public DateTime? EnrolledAt { get; private set; } = DateTime.UtcNow;

		public bool IsFinalized { get; private set; } = false;


		private Enrollment() { }

		public Enrollment(string studentId , Guid courseId)
		{
			StudentId = studentId;
			CourseId = courseId;

		}

		public void SetGrade(double grade , bool finalized = false)
		{
			Grade = grade;
			IsFinalized = finalized;
		}


    }
}

