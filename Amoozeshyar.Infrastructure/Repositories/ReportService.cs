using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Amoozeshyar.Application.Service
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReportService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentCourseReportDto>> GetStudentByCourseAsync(Guid courseId)
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)  
                .Include(e => e.Course)    
                .Where(e => e.CourseId == courseId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<StudentCourseReportDto>>(enrollments);
        }

        public async Task<IEnumerable<StudentTranscriptDto>> GetTranscriptAsync(string studentId)
        {
            var enrollments = await _context.Enrollments
                 .Include(e => e.Course)
                 .Where(e => e.StudentId == studentId)
                 .ToListAsync();


            return _mapper.Map<IEnumerable<StudentTranscriptDto>>(enrollments);
        }
    }
}
