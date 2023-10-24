using _22Percent_BE.Data.DTOs.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        [HttpPost("Create-Product")]
        public IActionResult create(CreateProductDto value)
        {
            return Ok();
        }
    }
}
