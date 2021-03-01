using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WeatherGetter.Models;

namespace WeatherGetter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public WeatherForecastController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherForecast))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetWeather(string city)
        {
            WeatherForecast result;

            if (_cache.TryGetValue(city, out result))
            {
                return new JsonResult(result);
            }

            return StatusCode(400, $"City '{city}' does not exist in our weather context. Try 'Wrocław', 'Warszawa', 'Poznań' or 'Łódź'.");
        }
    }
}


