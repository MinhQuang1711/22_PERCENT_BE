using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories.IngredientRepo;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IIngredientRepository _repo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IIngredientRepository repository)
        {
            _logger = logger;
            _repo=repository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> creaye(CreateIngredientDto create)
        {
            var result = await _repo.create(create);
           
                return Ok(result);
            
      
        }
    }
}