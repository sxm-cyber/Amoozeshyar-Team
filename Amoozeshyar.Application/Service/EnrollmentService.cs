using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public async Task EnrollStudentAsync(EnrollmentDto dto)
        {

            var course= await _unitOfWork.Courses.GetByIdAsync(dto.CourseId);
            if (course == null)
                throw new Exception("Course not Found");

            var currentEnrollments = await _unitOfWork.Enrollments.FindAsync(e => e.CourseId == dto.CourseId);
            if (currentEnrollments.Count() >= course.MaxStudents) 
            throw new Exception("Class is full");

            var enrollment = _mapper.Map<EnrollmentDto>(dto);
            await _unitOfWork.Enrollments.AddAsync(enrollment);
            await _unitOfWork.CommitAsync();

        }

        public async Task RemoveEnrollmentAsync(Guid enrollmentId)
        {
            var enrollment = await _unitOfWork.Enrollments.GetByIdAsync(enrollmentId);
            if (enrollment is null)
                throw new Exception("Enrollment not found");

            _unitOfWork.Enrollments.Remove(enrollment);
            await _unitOfWork.CommitAsync();



        }
    }
}
