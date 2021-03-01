using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WeatherGetter.Abstraction;
using WeatherGetter.Models;

namespace WeatherGetter.Utilities
{
    public class WeatherCronService : CronJobService
    {
        private readonly string ApiKey = "4f0845fe26db4203813194134212302";
        private readonly ILogger<WeatherCronService> _logger;
        private readonly IMemoryCache _cache;

        public WeatherCronService(IScheduleConfig<WeatherCronService> config, ILogger<WeatherCronService> logger, IMemoryCache cache)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
            _cache = cache;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("WeatherCronService started.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            GetForecastForCity("Wroclaw", "Wrocław");
            GetForecastForCity("Lodz", "Łódź");
            GetForecastForCity("Warszawa", "Warszawa");
            GetForecastForCity("Poznan", "Poznań");

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        private void GetForecastForCity(string city, string cacheCityName)
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

                    _cache.Set(cacheCityName, deserializedResult);
                }
            }
            catch (WebException e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
