using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Inventory : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;
        private string currentUser => User.FindFirstValue(ClaimTypes.Name);

        public Inventory(IServiceManagement serviceManagement)
        {
            _serviceManagement = serviceManagement;
        }

        [HttpGet("get-inventory")]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var dto = await _serviceManagement.InventoryServices.GetByName(currentUser); 
                return Ok(dto); 
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
