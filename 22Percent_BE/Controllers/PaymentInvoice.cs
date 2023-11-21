using _22Percent_BE.Data.DTOs.PaymentInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentInvoice : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;

        public PaymentInvoice(IServiceManagement serviceManagement) 
        {
            _serviceManagement = serviceManagement; 
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var entities= await _serviceManagement.PaymentInvoiceService.GetAll();
                return Ok(entities);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("get-by-filter")]
        public async Task<IActionResult> GetByFilter(SearchPaymentInvoiceDto dto, string currentUser)
        {
            try
            {
               var entities= await _serviceManagement.PaymentInvoiceService.GetByFilter(dto, currentUser);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePaymentInvoiceDto dto)
        {
            try
            {
                await _serviceManagement.PaymentInvoiceService.Create(dto);
                return Ok();
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
                var message= await _serviceManagement.PaymentInvoiceService.Delete(model.Id);
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
