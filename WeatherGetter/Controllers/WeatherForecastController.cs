using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using WeatherGetter.Models;

namespace WeatherGetter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string ApiKey = "4f0845fe26db4203813194134212302";
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCache _cache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public JsonResult GetWeatherInWroclaw()
        {

            var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(
                "https://api.worldweatheronline.com/premium/v1/weather.ashx?key=4f0845fe26db4203813194134212302&q=Wroclaw&format=json&num_of_days=7");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                var httpResponse = (System.Net.HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    var deserializedResult = JsonConvert.DeserializeObject<WeatherForecast>(result);

                    return new JsonResult(deserializedResult);
                }
            }
            catch (System.Net.WebException e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}


