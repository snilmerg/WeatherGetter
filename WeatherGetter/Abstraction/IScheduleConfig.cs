using System;

namespace WeatherGetter.Abstraction
{
    public interface IScheduleConfig<T>
    {
        string CronExpression { get; set; }

        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
