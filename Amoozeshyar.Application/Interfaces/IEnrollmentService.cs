using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
	public interface IEnrollmentService
	{
		Task EnrollStudentAsync(EnrollmentCommand command);

		Task RemoveEnrollmentAsync(Guid enrollmentId);
	}
}

