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
        public JsonResult GetWeather(string city)
        {
            WeatherForecast result;

            if (_cache.TryGetValue(city, out result))
            {
                return new JsonResult(result);
            }

            return new JsonResult($"City '{city}' does not exist in our weather context. Try 'Wrocław', 'Warszawa', 'Poznań' or 'Łódź'.");
        }
    }
}


