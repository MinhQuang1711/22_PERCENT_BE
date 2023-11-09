using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories.ProductRepo;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;

        public Products(IServiceManagement serviceManagement) 
        {
            _serviceManagement = serviceManagement;
        }

        [HttpPost("create")]
        public async Task<IActionResult> createProduct(CreateProductDto create)
        {
            try
            {
                var productId = Guid.NewGuid().ToString();
                await _serviceManagement.DetailProductService.CreateList(create.DetailProducts, productId);
                await _serviceManagement.ProductService.CreateProduct(create, productId);
                return Ok();
            }
            catch (Exception e) 
            {
                return StatusCode(500, e.Message);
            }  
        }

        [HttpDelete("delete")]

        public async Task<IActionResult> delete(BaseModel baseModel)
        {
            try
            {
                var msg=await _serviceManagement.ProductService.Delete(baseModel.Id);
                await _serviceManagement.DetailProductService.Delete(baseModel.Id);
                if(msg is null) 
                {
                    return BadRequest(msg); 
                }
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

       
    }
}
