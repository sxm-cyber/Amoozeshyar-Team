using System;
using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
	public interface ICourseService
	{
		Task AddCourseAsync(CourseDto dto);

		Task<IEnumerable<CourseDto>> GetAllCoursesAsync();

		Task UpdateCourseAsync(Guid id, CourseDto dto);

		Task DeleteCourseAsync(Guid id);

	}
}

