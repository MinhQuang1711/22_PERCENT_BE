﻿using _22Percent_BE.Data.DTOs.DetailImportInvoices;
using _22Percent_BE.Data.DTOs.ImportInvoices;
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


        /*
            * Thực hiện update ingredient sau khi thành công sẽ thêm mới ImportInvoice
        */
        [HttpPost("create")]
        public async Task<IActionResult> create(CreateImportInvoiceDto dto) 
        {
            try
            {
                foreach (var item in dto.DetailImportInvoice)
                {
                    var updateIngredientDto = item.ToUpdateIngredientDto(); 
                    var message= await _serviceManagement.IngredientService.update(updateIngredientDto);
                    if (message != null)
                    {
                        return BadRequest(message);
                    }
                }
                await _serviceManagement.ImportInvoiceService.Create(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
