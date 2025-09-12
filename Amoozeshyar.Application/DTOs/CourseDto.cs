using System;
namespace Amoozeshyar.Application.DTOs
{
	public class CourseDto
	{

		public string Name { get; set; } = string.Empty;

		public string Code { get; set; } = string.Empty;

		public int Units { get; set; }

		public string Semester { get; set; } = "Fall";

		public int MaxStudent { get; set; } = 30;

		public string TeacherId { get; set; } = string.Empty;
	}
}

