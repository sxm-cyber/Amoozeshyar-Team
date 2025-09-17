namespace Amoozeshyar.Application.DTOs
{
	public class EnrollmentCommand
	{
		public Guid StudentId { get; set; } = Guid.NewGuid();

		public Guid CourseId { get; set; }

		public Guid TeacherId { get; set; }

		public int MaxStudents { get; set; }

	}
}

