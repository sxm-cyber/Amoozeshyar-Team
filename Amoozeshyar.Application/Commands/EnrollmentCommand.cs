namespace Amoozeshyar.Application.DTOs
{
	public class EnrollmentCommand
	{
		public string StudentId { get; set; } = string.Empty;

		public Guid CourseId { get; set; }

		public string TeacherId { get; set; }

		public int MaxStudents { get; set; }

	}
}

