using Amoozeshyar.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amoozeshyar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        
        private readonly IReportService _reportServce;

        public ReportsController(IReportService reportService)
        {
            _reportServce = reportService;
        }


        [HttpGet("course/{courseId}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> GetStudentsByCourse(Guid courseId)
        {
            var report = await _reportServce.GetStudentsByCourseAsync(courseId);

            return Ok(report);
        }


        [HttpGet("transcript/{studentId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTranscript(Guid studentId)
        {
            var transcript = await _reportServce.GetTranscriptAsync(studentId);

            return Ok(transcript);
        }
    }
}
