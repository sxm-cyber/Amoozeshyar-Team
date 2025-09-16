using System;
namespace Amoozeshyar.Domain.Models
{
	public class Enrollment
	{
		public Guid Id { get; private set; } = Guid.NewGuid();


        public string Semester { get; private set; } = "Fall";

        public string TeacherId { get; private set; } = string.Empty;


        public int MaxStudents { get; private set; } = 30;

        public string StudentId { get; private set; } = string.Empty;
		public ApplicationUser? Student { get; private set; }


        public Guid CourseId { get; private set; }
        public Course? Course { get; private set; }


		public double? Grade { get; private set; }

		public DateTime? EnrolledAt { get; private set; } = DateTime.UtcNow;

		public bool IsFinalized { get; private set; } = false;


		private Enrollment() { }

		public Enrollment(string studentId , Guid courseId , string teacherId)
		{
			Id = Guid.NewGuid();
			StudentId = studentId;
			CourseId = courseId;
			TeacherId = teacherId;

		}

		public void SetGrade(double grade , bool finalized = false)
		{
			Grade = grade;
			IsFinalized = finalized;
		}
    }
}

