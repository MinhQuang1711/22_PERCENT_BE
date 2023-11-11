using _22Percent_BE.Data.Entities;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleInvoices : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;

        public SaleInvoices(IServiceManagement serviceManagement) 
        {
            _serviceManagement = serviceManagement;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var dtos = await _serviceManagement.SaleInvoiceService.GetAll(); 
                return Ok(dtos);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("search-by-id")]
        public async Task<IActionResult> GetById(BaseModel model)
        {
            try
            {
                var dto = await _serviceManagement.SaleInvoiceService.GetById(model.Id); 
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
