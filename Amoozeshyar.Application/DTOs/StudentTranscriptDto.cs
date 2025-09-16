namespace Amoozeshyar.Application.DTOs
{
	public class StudentTranscriptDto
	{
		public string CourseName { get; set; } = string.Empty;

		public string Semester { get; set; } = string.Empty;

		public double? Grade { get; set; }
	}
}

