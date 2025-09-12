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
            var enrollment = _mapper.Map<Enrollment>(dto);

            await _unitOfWork.Enrollments.AddAsync(enrollment);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveEnrollmentAsync(Guid enrollmentId)
        {
            var enrollment = await _unitOfWork.Enrollments.GetByIdAsync(enrollmentId);
            if (enrollment == null)
                throw new Exception("Enrollment not found");

            _unitOfWork.Enrollments.Remove(enrollment);
            await _unitOfWork.CommitAsync();



        }
    }
}
