using _22Percent_BE.Data.DTOs.SaleInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Enums;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleInvoice : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;
        private string currentUser => User.FindFirstValue(ClaimTypes.Name);

        public SaleInvoice(IServiceManagement serviceManagement) 
        {
            _serviceManagement = serviceManagement;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var dtos = await _serviceManagement.SaleInvoiceService.GetAll(currentUser); 
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

        [HttpPost("search-by-filter")]
        public async Task<IActionResult> GetByFilter(SearchSaleInvoiceDto dto)
        {
            try
            {
                var dtos = await _serviceManagement.SaleInvoiceService.GetByFilter(dto,currentUser);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSaleInvoiceDto dto)
        {
            try
            {
                if (Enum.IsDefined(typeof(PaymentType), dto.PaymentType))
                {
                    await _serviceManagement.SaleInvoiceService.Create(dto, currentUser);
                    return Ok();
                }
                return BadRequest(Message.PaymentTypeNotExist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(BaseModel model)
        {
            try
            {
                var message= await _serviceManagement.SaleInvoiceService.Delete(model.Id);
                if (message != null)
                {
                    return NotFound(message);
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
