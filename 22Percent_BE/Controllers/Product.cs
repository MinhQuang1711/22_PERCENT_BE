using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;

        public Product(IServiceManagement serviceManagement)
        {
            _serviceManagement = serviceManagement;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var dtos = await _serviceManagement.ProductService.GetAll();
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("search-by-filter")]
        public async Task<IActionResult> SeachByName(SearchProductDto search) 
        {
            try
            {
                if(search.FromPrice!=null && search.ToPrice == null)
                {
                    return BadRequest(Message.SelectPriceRange);
                }
                if(search.FromPrice==null && search.ToPrice!=null)
                {
                    return BadRequest(Message.SelectPriceRange);
                }    
                var dtos= await _serviceManagement.ProductService.SearchByFilter(search);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
