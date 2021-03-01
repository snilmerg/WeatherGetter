using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WeatherGetter.Abstraction;

namespace WeatherGetter.Utilities
{
    public class WeatherCronService : CronJobService
    {
        private readonly ILogger<WeatherCronService> _logger;
        private readonly IMemoryCache _cache;

        public WeatherCronService(IScheduleConfig<WeatherCronService> config, ILogger<WeatherCronService> logger, IMemoryCache cache)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _cache = cache;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            WeatherRequestsHandler.GetWeatherForecast(_cache, _logger);

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
