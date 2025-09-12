using System;
using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
	public interface IReportService
	{
		Task<IEnumerable<StudentCourseReportDto>> GetStudentByCourseAsync(Guid courseId);

		Task<IEnumerable<StudentTranscriptDto>> GetTranscriptAsync(string studentId);
	}
}

