using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("course/{courseId}")]
        [Authorize(Roles = Roles.Admin + "," + Roles.Teacher)]
        public async Task<IActionResult> GetStudentsByCourse(Guid courseId)
        {
            var result = await _reportService.GetStudentByCourseAsync(courseId);
            return Ok(result);
        }

     
        [HttpGet("transcript/{studentId}")]
        [Authorize(Roles = Roles.Admin + "," + Roles.Teacher + "," + Roles.Student)]
        public async Task<IActionResult> GetTranscript(string studentId)
        {
            var result = await _reportService.GetTranscriptAsync(studentId);
            return Ok(result);
        }
    }
}
