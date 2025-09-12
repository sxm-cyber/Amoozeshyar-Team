using System;
using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
	public interface IEnrollmentService
	{
		Task EnrollStudentAsync(EnrollmentDto dto);

		Task RemoveEnrollmentAsync(Guid enrollmentId);
	}
}

