using Amoozeshyar.Domain.Models;

namespace Amoozeshyar.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetStudentByCourseAsync(Guid courseId);

        Task<IEnumerable<Enrollment>> GetTranscriptAsync(string studentId);
    }
}

