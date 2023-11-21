using _22Percent_BE.Data.DTOs.Report;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _22Percent_BE.Controllers
{
    [Authorize]
    [Route("api/report")]
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
        [HttpPost("get-by-filter")]
        public async Task<IActionResult> GetByFilter(SearchReportDto dto)
        {
            try
            {
                var reports = await _serviceManagement.ReportService.GetByFilter(currentUser, dto);
                return Ok(reports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateReportDto dto)
        {
            try
            {
                await _serviceManagement.ReportService.Create(dto, currentUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(BaseModel dto)
        {
            try
            {
                var message= await _serviceManagement.ReportService.Delete(dto.Id);
                if (message != null)
                {
                    return BadRequest(message); 
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
