using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain;
using Amoozeshyar.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amoozeshyar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        //private readonly IEnrollmentRepository _reportService;
        private readonly IReportService _reportServce;

        public ReportsController(IReportService reportService)
        {
            _reportServce = reportService;
        }


        //[HttpGet("course/{courseId}")]
        //[Authorize(Roles = Roles.Admin + "," + Roles.Teacher)]
        //public async Task<IActionResult> GetStudentsByCourse(Guid courseId)
        //{
        //    var result = await _reportService.GetStudentByCourseAsync(courseId);
        //    return Ok(result);
        //}


        //[HttpGet("transcript/{studentId}")]
        //[Authorize(Roles = Roles.Admin + "," + Roles.Teacher + "," + Roles.Student)]
        //public async Task<IActionResult> GetTranscript(string studentId)
        //{
        //    var result = await _reportService.GetTranscriptAsync(studentId);
        //    return Ok(result);
        //}
    }
}
