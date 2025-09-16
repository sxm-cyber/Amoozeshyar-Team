using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Interfaces;

namespace Amoozeshyar.Application.Service
{
    public class GradingService : IGradingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GradingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task SetGradeAsync(GradeCommand dto)
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
