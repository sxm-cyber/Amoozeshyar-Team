using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        // POST: api/enrollments
        [HttpPost]
        public async Task<IActionResult> Enroll([FromBody] EnrollmentDto dto)
        {
            await _enrollmentService.EnrollStudentAsync(dto);
            return Ok("Student enrolled successfully.");
        }

        // DELETE: api/enrollments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _enrollmentService.RemoveEnrollmentAsync(id);
            return Ok("Enrollment removed successfully.");
        }
    }
}
