using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amoozeshyar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Add([FromBody] CourseCommand dto)
        {
            await _courseService.AddCourseAsync(dto);
            return Ok("Course added successfully.");
        }

 
        [HttpPut("{id}")]
        [Authorize(Roles ="Admin,Teacher")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CourseCommand dto)
        {
            await _courseService.UpdateCourseAsync(id, dto);
            return Ok("Course updated successfully.");
        }

     
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _courseService.DeleteCourseAsync(id);
            return Ok("Course deleted successfully.");
        }
    }
}
