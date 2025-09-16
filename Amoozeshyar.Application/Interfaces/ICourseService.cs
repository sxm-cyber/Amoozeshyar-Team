using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
	public interface ICourseService
	{
		Task AddCourseAsync(CourseCommand command);

		Task<IEnumerable<CourseCommand>> GetAllCoursesAsync();

		Task UpdateCourseAsync(Guid id, CourseCommand command);

		Task DeleteCourseAsync(Guid id);

	}
}

