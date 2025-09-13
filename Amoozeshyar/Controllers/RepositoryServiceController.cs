using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amoozeshyar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: api/reports/course/{courseId}
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetStudentsByCourse(Guid courseId)
        {
            var result = await _reportService.GetStudentByCourseAsync(courseId);
            return Ok(result);
        }

        // GET: api/reports/transcript/{studentId}
        [HttpGet("transcript/{studentId}")]
        public async Task<IActionResult> GetTranscript(string studentId)
        {
            var result = await _reportService.GetTranscriptAsync(studentId);
            return Ok(result);
        }
    }
}
