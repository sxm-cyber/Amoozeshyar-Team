using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshyar.Application.Service
{
    public class GradingServise : IGradingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GradingServise(IUnitOfWork unitOfWork)
        {
          _unitOfWork = unitOfWork;
        }
        public async Task SetGradeAsync(GradeDto dto)
        {
            var enrollement = await _unitOfWork.Enrollments.GetByIdAsync(dto.EnrollmentId);
            if (enrollement == null)
                throw new Exception("Enrollment not Found");


            var student = await _unitOfWork .Users .GetByIdAsync(Guid.Parse(enrollement.StudentId));
            if (student == null)
                throw new Exception("Student not Found");


            _unitOfWork.Enrollments.Update(enrollement);
            await _unitOfWork.CommitAsync();
        }
    }
}
