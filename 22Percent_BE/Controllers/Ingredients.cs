using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _22Percent_BE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Ingredients : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;
        private string currentUser => User.FindFirstValue(ClaimTypes.Name);

        public Ingredients(IServiceManagement serviceManagement) 
        {
            _serviceManagement= serviceManagement;
        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll() 
        {
            var ingredients = await _serviceManagement.IngredientService.getAll();
            ingredients = ingredients.Where(e => e.CreateUser == currentUser).ToList();
            return Ok(ingredients);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> create(CreateIngredientDto create)
        {
            if (create.ImportPrice == 0)
            {
                return BadRequest("Giá nguyên liệu phải lớn hơn 0");
            }
            var result = await _serviceManagement.IngredientService.create(create,currentUser);
            if (result == true)
            {
                return Ok();
            }
            return StatusCode(500);
        }

        [HttpPost("Search-By-Filter")]
        public async Task<IActionResult> searchByFilter(SearchIngredientDto search)
        {
            var result= await _serviceManagement.IngredientService.searchByFilter(search);
            result = result.Where(e => e.CreateUser == currentUser).ToList();
            return Ok(result);
        }

        [HttpPost("Search-By-Id")]
        public async Task<IActionResult> searchById(IngredientSaechByIdDto search)
        {
            var result =await _serviceManagement.IngredientService.searchById(search.Id);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(204);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> update(UpdateIngredientDto update)
        {
            if (update.ImportPrice == 0)
            {
                return BadRequest("Giá nguyên liệu phải lớn hơn 0");
            }
            var result = await _serviceManagement.IngredientService.update(update);
            if(result == null)
            {
                return Ok();
            }
            return NotFound(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> delete(IngredientSaechByIdDto delete)
        {
            var result = await _serviceManagement.IngredientService.detete(delete.Id);
            if (result == true)
            {
                return Ok();
            }
            return NotFound("Nguyên liệu không tồn tại");
        }
    }
}
