namespace Amoozeshyar.Application.DTOs
{
	public class StudentCourseReportDto
	{

		public string FullName { get; set; }

		public Guid StudentId { get; set; } = Guid.NewGuid();

		public string StudentName { get; set; } = string.Empty;

		public string CourseName { get; set; } = string.Empty;

		public string Semester { get; set; } = string.Empty;

		public double? Grade { get; set; }

	}
}

