using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Domain.Models;
using AutoMapper;

namespace Amoozeshyar.Application.Service
{
    public class EnrollmentService : IEnrollmentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task EnrollStudentAsync(EnrollmentCommand command)
        {

            var course = await _unitOfWork.Courses.GetByIdAsync(command.CourseId);
            if (course == null)
                throw new Exception("Course not Found");

            var currentEnrollments = await _unitOfWork.Enrollments
                .FindAsync(e => e.CourseId == command.CourseId && e.TeacherId == command.TeacherId);

            if (currentEnrollments.Count() >= command.MaxStudents)
                throw new Exception("Class is full");

            var enrollment = _mapper.Map<Enrollment>(command);


            await _unitOfWork.Enrollments.AddAsync(enrollment);
            await _unitOfWork.CommitAsync();

        }

        public async Task RemoveEnrollmentAsync(Guid enrollmentId)
        {
            var enrollment = await _unitOfWork.Enrollments.GetByIdAsync(enrollmentId);
            if (enrollment is null)
                throw new Exception("Enrollment not found");

            _unitOfWork.Enrollments.DeleteAsync(enrollment);
            await _unitOfWork.CommitAsync();

        }
    }
}
