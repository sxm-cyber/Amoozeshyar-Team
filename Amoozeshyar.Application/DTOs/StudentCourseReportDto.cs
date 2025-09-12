using System;
namespace Amoozeshyar.Application.DTOs
{
	public class StudentCourseReportDto
	{
		public string StudentId { get; set; } = string.Empty;

		public string StudentName { get; set; } = string.Empty;

		public string CourseName { get; set; } = string.Empty;

		public string Semester { get; set; } = string.Empty;

		public double? Grade { get; set; }

	}
}

