namespace Amoozeshyar.Application.DTOs
{
	public class GradeCommand
	{
		public Guid EnrollmentId { get; set; }

		public double Grade { get; set; }

        public bool IsFinalized { get; set; } = false;
    }
}

