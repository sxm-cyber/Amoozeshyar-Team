using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Domain.Models;
using AutoMapper;

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

        public async Task AddCourseAsync(CourseCommand command)
        {

            var course = _mapper.Map<Course>(command);


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

        public async Task<IEnumerable<CourseCommand>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();

            return _mapper.Map<IEnumerable<CourseCommand>>(courses);
        }

        public async Task UpdateCourseAsync(Guid id, CourseCommand command)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course is null)
                throw new Exception("Course not found");

            course.UpdateCourse(command.Name, command.Code, command.Units);

            _unitOfWork.Courses.Update(course);
            await _unitOfWork.CommitAsync();
        }
    }
}
