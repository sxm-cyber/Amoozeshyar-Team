using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Domain.Models;
using Amoozeshyar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Amoozeshyar.Application.Service
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;

        public EnrollmentRepository(ApplicationDbContext context/*, IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
        }

        public async Task<IEnumerable<Enrollment>> GetStudentByCourseAsync(Guid courseId)
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.CourseId == courseId)
                .ToListAsync();

            return enrollments;
            //return _mapper.Map<IEnumerable<StudentCourseReportDto>>(enrollments);
        }

        public async Task<IEnumerable<Enrollment>> GetTranscriptAsync(string studentId)
        {
            var enrollments = await _context.Enrollments

                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToListAsync();

            return enrollments;
            //return _mapper.Map<IEnumerable<StudentTranscriptDto>>(enrollments);
        }
    }
}
