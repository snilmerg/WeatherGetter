using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherGetter.Abstraction;

namespace WeatherGetter.Utilities
{
    public class WeatherCronService : CronJobService
    {
        private readonly ILogger<WeatherCronService> _logger;

        public WeatherCronService(IScheduleConfig<WeatherCronService> config, ILogger<WeatherCronService> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("WeatherCronService started.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} WeatherCronService is working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("WeatherCronService is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
