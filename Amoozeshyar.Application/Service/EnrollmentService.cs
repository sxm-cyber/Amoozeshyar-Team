using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshyar.Application.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        public Task EnrollStudentAsync(EnrollmentDto dto)
        {
            throw new NotImplementedException();
        }

        public Task RemoveEnrollmentAsync(Guid enrollmentId)
        {
            throw new NotImplementedException();
        }
    }
}
