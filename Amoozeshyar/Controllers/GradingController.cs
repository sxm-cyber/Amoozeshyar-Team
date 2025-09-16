using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amoozeshyar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradingController : ControllerBase
    {
        private readonly IGradingService _gradingService;

        public GradingController(IGradingService gradingService)
        {
            _gradingService = gradingService;
        }

        
        [HttpPost("set-grade"), Authorize(Roles = "Teacher")]
        public async Task<IActionResult> SetGrade([FromBody] GradeCommand dto)
        {
            try
            {
                await _gradingService.SetGradeAsync(dto);
                return Ok("Grade set successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
