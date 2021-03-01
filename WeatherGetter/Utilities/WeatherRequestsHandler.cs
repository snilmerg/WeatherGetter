using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using WeatherGetter.Models;

namespace WeatherGetter.Utilities
{
    public static class WeatherRequestsHandler
    {
        private static readonly string ApiKey = "4f0845fe26db4203813194134212302";

        public static void GetWeatherForecast(IMemoryCache cache, ILogger logger)
        {
            GetForecastForCity("Wroclaw", "Wrocław", cache, logger);
            GetForecastForCity("Lodz", "Łódź", cache, logger);
            GetForecastForCity("Warszawa", "Warszawa", cache, logger);
            GetForecastForCity("Poznan", "Poznań", cache, logger);
        }

        private static void GetForecastForCity(string city, string cacheCityName, IMemoryCache cache, ILogger logger)
        {
            var url = "https://api.worldweatheronline.com/premium/v1/weather.ashx?key=" + ApiKey + "&q=" + city + "&format=json&num_of_days=7";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    var deserializedResult = JsonConvert.DeserializeObject<WeatherForecast>(result);

                    cache.Set(cacheCityName, deserializedResult);
                }
            }
            catch (WebException e)
            {
                logger.LogError(e.Message);
            }
        }
    }
}
