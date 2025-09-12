using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshyar.Application.Service
{
    public class CourseService : ICourseService

      

    {
        public Task AddCourseAsync(CourseDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCourseAsync(Guid id, CourseDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
