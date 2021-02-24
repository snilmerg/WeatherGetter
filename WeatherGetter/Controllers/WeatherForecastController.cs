using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace WeatherGetter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCache _cache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public JsonResult GetWeatherInWroclaw(string city)
        {
            string result;

            if (_cache.TryGetValue(city, out result))
            {
                return new JsonResult(result);
            }

            return new JsonResult($"City {city} does not exist in our weather context. Try 'Wrocław', 'Warszawa', 'Poznań' or 'Łódź'.");
        }
    }
}


