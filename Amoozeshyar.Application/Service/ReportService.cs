using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshyar.Application.Service
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        
        public async Task<IEnumerable<StudentCourseReportDto>> GetStudentByCourseAsync(Guid courseId)
        {
            var enrolloment = await _unitOfWork.Enrollments.FindAsync(e =>e.CourseId == courseId);

            return _mapper.Map<IEnumerable<StudentCourseReportDto>>(enrolloment);
        }

        public async Task<IEnumerable<StudentTranscriptDto>> GetTranscriptAsync(string studentId)
        {
           var enrolloment = await _unitOfWork.Enrollments.FindAsync(e=> e.StudentId == studentId);


            return _mapper.Map<IEnumerable<StudentTranscriptDto>>(enrolloment);
            


        }
    }
}
