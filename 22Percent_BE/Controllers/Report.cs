using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _22Percent_BE.Controllers
{
    [Authorize]
    [Route("api/Report")]
    [ApiController]
    public class Report : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;
        private string currentUser => User.FindFirstValue(ClaimTypes.Name);

        public Report(IServiceManagement serviceManagement) 
        {
            _serviceManagement = serviceManagement;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                return Ok(await _serviceManagement.ReportService.GetByUserName(currentUser));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message); 
            }
        }
    }
}
