using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amoozeshyar.Application.Service
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCourseAsync(CourseDto dto)
        {
            
            var course = _mapper.Map<Course>(dto);
            

            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCourseAsync(Guid id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course is null)
                throw new Exception("Course not found");

            _unitOfWork.Courses.Remove(course);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task UpdateCourseAsync(Guid id, CourseDto dto)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course is null)
                throw new Exception("Course not found");

            course.UpdateCourse(dto.Name, dto.Code, dto.Units, dto.Semester, dto.MaxStudent);
            
            //_mapper.Map(dto, course);

            _unitOfWork.Courses.Update(course);
            await _unitOfWork.CommitAsync();
        }
    }
}
