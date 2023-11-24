using _22Percent_BE.Data.DTOs.DetailImportInvoices;
using _22Percent_BE.Data.DTOs.ImportInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportInvoice : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;
        private string currentUser => User.FindFirstValue(ClaimTypes.Name);

        public ImportInvoice(IServiceManagement serviceManagement)
        {
            _serviceManagement = serviceManagement;
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var dtos = await _serviceManagement.ImportInvoiceService.GetAll(currentUser);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("get-by-filter")]
        public async Task<IActionResult> GetByFilter(SearchImportInvoiceDto search)
        {
            try
            {

                var dtos = await _serviceManagement.ImportInvoiceService.GetByFilter(search,currentUser);
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
                var message =await  _serviceManagement.IngredientService.updateList(updateIngredientDtoList);
                if (message != null)
                {
                    return BadRequest(message); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            try
            {
                var updateDetailIngredientList = dto.ToListDetailIngredient();
                var message = await _serviceManagement.DetailIngredientService.UpdateList(updateDetailIngredientList, true);
                if (message != null)
                {
                    return BadRequest(message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            try
            {
                await _serviceManagement.ImportInvoiceService.Create(dto, currentUser);
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
