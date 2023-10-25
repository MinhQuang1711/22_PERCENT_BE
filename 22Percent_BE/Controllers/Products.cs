using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories.ProductRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public Products(IProductRepository productRepository) 
        {
            _productRepository= productRepository;
        }

        [HttpPost("Create-Product")]
        public async Task<IActionResult> create(CreateProductDto value)
        {
            var resul= await _productRepository.create(value);  
            if (resul!=null)
            {
                return BadRequest(resul);   
            }
            return Ok();
        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> getAll() 
        {
            return Ok(await _productRepository.getAll());   
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> delete(BaseModel model)
        {
            var result= await _productRepository.delete(model);
            if (result != null)
            {
                return BadRequest(result);
            }
            return Ok();    
        }
    }
}
