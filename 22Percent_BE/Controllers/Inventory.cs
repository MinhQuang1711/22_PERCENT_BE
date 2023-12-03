using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _22Percent_BE.Controllers
{
    [Authorize]
    [Route("api/inventory")]
    [ApiController]
    public class Inventory : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;
        private string currentUser => User.FindFirstValue(ClaimTypes.Name);

        public Inventory(IServiceManagement serviceManagement) 
        {
            _serviceManagement = serviceManagement; 
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var dto = await _serviceManagement.DetailIngredientService.GetAllByUserName(currentUser);
                return Ok(dto);

            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
