using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Interfaces;

namespace Amoozeshyar.Application.Service
{
    public class ReportService : IReportService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public ReportService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<StudentCourseReportDto>> GetStudentsByCourseAsync(Guid courseId)
        {
            var enrollment = await _enrollmentRepository.GetByCourseIdAsync(courseId);

            return enrollment.Select(e => new StudentCourseReportDto
            {
                StudentId = e.StudentId,
                FullName = e.Student?.FullName,
                CourseName = e.Course?.Name
            });
            
        }

        public async Task<IEnumerable<StudentTranscriptDto>> GetTranscriptAsync(Guid studentId)
        {
            var enrolllment = await _enrollmentRepository.GetByStudentIdAsync(studentId);

            return enrolllment.Select(e => new StudentTranscriptDto
            {
                CourseName = e.Course?.Name,
                Grade = e.Grade
            });
           
        }
    }
}
