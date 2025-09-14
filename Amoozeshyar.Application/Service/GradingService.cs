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
    public class GradingService : IGradingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GradingService(IUnitOfWork unitOfWork)
        {
          _unitOfWork = unitOfWork;
        }
        public async Task SetGradeAsync(GradeDto dto)
        {
            
            var enrollement = await _unitOfWork.Enrollments.GetByIdAsync(dto.EnrollmentId);
            if (enrollement == null)
                throw new Exception("Enrollment not Found");


            enrollement.SetGrade(dto.Grade, dto.IsFinalized);


            _unitOfWork.Enrollments.Update(enrollement);
            await _unitOfWork.CommitAsync();
        }
    }
}
