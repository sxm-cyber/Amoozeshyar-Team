using System;
namespace Amoozeshyar.Application.DTOs
{
	public class EnrollmentDto
	{
		public string StudentId { get; set; } = string.Empty;

		public Guid CourseId { get; set; }
	}
}

