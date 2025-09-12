using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshyar.Application.Service
{
    public class RepositoryService : IReportService
    {
        public Task<IEnumerable<StudentCourseReportDto>> GetStudentByCourseAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentTranscriptDto>> GetTranscriptAsync(string studentId)
        {
            throw new NotImplementedException();
        }
    }
}
