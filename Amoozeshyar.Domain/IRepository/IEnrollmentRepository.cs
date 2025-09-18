using Amoozeshyar.Domain.Models;

namespace Amoozeshyar.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetByCourseIdAsync(Guid courseId);

        Task<IEnumerable<Enrollment>> GetByStudentIdAsync(Guid studentId);
    }
}

