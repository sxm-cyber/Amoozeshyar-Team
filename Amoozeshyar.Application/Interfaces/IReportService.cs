using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<StudentCourseReportDto>> GetStudentsByCourseAsync(Guid courseIdd);

        Task<IEnumerable<StudentTranscriptDto>> GetTranscriptAsync(Guid studentId);

    }
}
