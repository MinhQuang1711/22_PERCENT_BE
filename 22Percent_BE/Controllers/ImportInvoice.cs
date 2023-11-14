using _22Percent_BE.Data.DTOs.DetailImportInvoices;
using _22Percent_BE.Data.DTOs.ImportInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportInvoice : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;

        public ImportInvoice(IServiceManagement serviceManagement)
        {
            _serviceManagement = serviceManagement;
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var dtos = await _serviceManagement.ImportInvoiceService.GetAll();
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById(BaseModel baseModel)
        {
            try
            {
                var dto = await _serviceManagement.ImportInvoiceService.GetById(baseModel.Id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /*
            * Thực hiện update ingredient sau khi thành công sẽ thêm mới ImportInvoice
        */
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateImportInvoiceDto dto) 
        {
            try
            {
                var updateIngredientDtoList = dto.DetailImportInvoice.Select(e => e.ToUpdateIngredientDto()).ToList();
                var message = await _serviceManagement.IngredientService.updateList(updateIngredientDtoList);
                if (message != null)
                {
                    return BadRequest(message);
                }
                await _serviceManagement.ImportInvoiceService.Create(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(BaseModel baseModel)
        {
            try
            {
                var message = await _serviceManagement.ImportInvoiceService.Delete(baseModel.Id); 
                if(message!= null)
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
