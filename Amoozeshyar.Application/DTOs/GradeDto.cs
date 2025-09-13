using System;
namespace Amoozeshyar.Application.DTOs
{
	public class GradeDto
	{
		public Guid EnrollmentId { get; set; }

		public double Grade { get; set; }

        public bool IsFinalized { get; set; } = false;
    }
}

