using System;
using WeatherGetter.Abstraction;

namespace WeatherGetter.Utilities
{
    public class ScheduleConfig<T> : IScheduleConfig<T>
    {
        public string CronExpression { get; set; }

        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
