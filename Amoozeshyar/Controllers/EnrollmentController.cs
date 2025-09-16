using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amoozeshyar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

     
        [HttpPost]
        [Authorize(Roles =Roles.Student)]
        public async Task<IActionResult> Enroll([FromBody] EnrollmentCommand dto)
        {
            await _enrollmentService.EnrollStudentAsync(dto);
            return Ok("Student enrolled successfully.");
        }

      
        [HttpDelete("{id}")]
        [Authorize(Roles =Roles.Admin+","+Roles.Teacher)]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _enrollmentService.RemoveEnrollmentAsync(id);
            return Ok("Enrollment removed successfully.");
        }
    }
}
