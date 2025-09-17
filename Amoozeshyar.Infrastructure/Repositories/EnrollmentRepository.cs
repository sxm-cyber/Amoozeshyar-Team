using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Domain.Models;
using Amoozeshyar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Amoozeshyar.Application.Service
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<IEnumerable<Enrollment>> GetByCourseIdAsync(Guid courseId)
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.CourseId == courseId)
                .ToListAsync();

            return enrollments;
            
        }

        public async Task<IEnumerable<Enrollment>> GetByStudentIdAsync(Guid studentId)
        {
            var enrollments = await _context.Enrollments

                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToListAsync();

            return enrollments;
            
        }
    }
}
