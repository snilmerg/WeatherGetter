using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherGetter.Models
{
    public class WeatherForecast
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("request")]
        public List<Request> Request { get; set; }

        [JsonProperty("current_condition")]
        public List<CurrentCondition> CurrentCondition { get; set; }

        [JsonProperty("weather")]
        public List<WeatherElement> Weather { get; set; }

        [JsonProperty("ClimateAverages")]
        public List<ClimateAverage> ClimateAverages { get; set; }
    }

    public class ClimateAverage
    {
        [JsonProperty("month")]
        public List<Month> Month { get; set; }
    }

    public class Month
    {
        [JsonProperty("index")]

        public int Index { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avgMinTemp")]
        public string AvgMinTemp { get; set; }

        [JsonProperty("avgMinTemp_F")]
        public string AvgMinTempF { get; set; }

        [JsonProperty("absMaxTemp")]
        public string AbsMaxTemp { get; set; }

        [JsonProperty("absMaxTemp_F")]
        public string AbsMaxTempF { get; set; }

        [JsonProperty("avgDailyRainfall")]
        public string AvgDailyRainfall { get; set; }
    }

    public class CurrentCondition
    {
        [JsonProperty("observation_time")]
        public string ObservationTime { get; set; }

        [JsonProperty("temp_C")]

        public int TempC { get; set; }

        [JsonProperty("temp_F")]

        public int TempF { get; set; }

        [JsonProperty("weatherCode")]

        public int WeatherCode { get; set; }

        [JsonProperty("weatherIconUrl")]
        public List<Weather> WeatherIconUrl { get; set; }

        [JsonProperty("weatherDesc")]
        public List<Weather> WeatherDesc { get; set; }

        [JsonProperty("windspeedMiles")]

        public int WindspeedMiles { get; set; }

        [JsonProperty("windspeedKmph")]

        public int WindspeedKmph { get; set; }

        [JsonProperty("winddirDegree")]

        public int WinddirDegree { get; set; }

        [JsonProperty("winddir16Point")]
        public string Winddir16Point { get; set; }

        [JsonProperty("precipMM")]
        public double PrecipMm { get; set; }

        [JsonProperty("precipInches")]
        public double PrecipInches { get; set; }

        [JsonProperty("humidity")]

        public int Humidity { get; set; }

        [JsonProperty("visibility")]

        public int Visibility { get; set; }

        [JsonProperty("visibilityMiles")]

        public int VisibilityMiles { get; set; }

        [JsonProperty("pressure")]

        public int Pressure { get; set; }

        [JsonProperty("pressureInches")]

        public int PressureInches { get; set; }

        [JsonProperty("cloudcover")]

        public int Cloudcover { get; set; }

        [JsonProperty("FeelsLikeC")]

        public int FeelsLikeC { get; set; }

        [JsonProperty("FeelsLikeF")]

        public int FeelsLikeF { get; set; }

        [JsonProperty("uvIndex")]

        public int UvIndex { get; set; }
    }

    public class Weather
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Request
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }
    }

    public class WeatherElement
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("astronomy")]
        public List<Astronomy> Astronomy { get; set; }

        [JsonProperty("maxtempC")]

        public int MaxtempC { get; set; }

        [JsonProperty("maxtempF")]

        public int MaxtempF { get; set; }

        [JsonProperty("mintempC")]

        public int MintempC { get; set; }

        [JsonProperty("mintempF")]

        public int MintempF { get; set; }

        [JsonProperty("avgtempC")]

        public int AvgtempC { get; set; }

        [JsonProperty("avgtempF")]

        public int AvgtempF { get; set; }

        [JsonProperty("totalSnow_cm")]
        public double TotalSnowCm { get; set; }

        [JsonProperty("sunHour")]
        public double SunHour { get; set; }

        [JsonProperty("uvIndex")]

        public int UvIndex { get; set; }

        [JsonProperty("hourly")]
        public List<Hourly> Hourly { get; set; }
    }

    public class Astronomy
    {
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        [JsonProperty("moonrise")]
        public string Moonrise { get; set; }

        [JsonProperty("moonset")]
        public string Moonset { get; set; }

        [JsonProperty("moon_phase")]
        public string MoonPhase { get; set; }

        [JsonProperty("moon_illumination")]

        public int MoonIllumination { get; set; }
    }

    public class Hourly
    {
        [JsonProperty("time")]

        public int Time { get; set; }

        [JsonProperty("tempC")]

        public int TempC { get; set; }

        [JsonProperty("tempF")]

        public int TempF { get; set; }

        [JsonProperty("windspeedMiles")]

        public int WindspeedMiles { get; set; }

        [JsonProperty("windspeedKmph")]

        public int WindspeedKmph { get; set; }

        [JsonProperty("winddirDegree")]

        public int WinddirDegree { get; set; }

        [JsonProperty("winddir16Point")]
        public string Winddir16Point { get; set; }

        [JsonProperty("weatherCode")]

        public int WeatherCode { get; set; }

        [JsonProperty("weatherIconUrl")]
        public List<Weather> WeatherIconUrl { get; set; }

        [JsonProperty("weatherDesc")]
        public List<Weather> WeatherDesc { get; set; }

        [JsonProperty("precipMM")]
        public double PrecipMm { get; set; }

        [JsonProperty("precipInches")]
        public double PrecipInches { get; set; }

        [JsonProperty("humidity")]

        public int Humidity { get; set; }

        [JsonProperty("visibility")]

        public int Visibility { get; set; }

        [JsonProperty("visibilityMiles")]

        public int VisibilityMiles { get; set; }

        [JsonProperty("pressure")]

        public int Pressure { get; set; }

        [JsonProperty("pressureInches")]

        public int PressureInches { get; set; }

        [JsonProperty("cloudcover")]

        public int Cloudcover { get; set; }

        [JsonProperty("HeatIndexC")]

        public int HeatIndexC { get; set; }

        [JsonProperty("HeatIndexF")]

        public int HeatIndexF { get; set; }

        [JsonProperty("DewPointC")]
        public int DewPointC { get; set; }

        [JsonProperty("DewPointF")]

        public int DewPointF { get; set; }

        [JsonProperty("WindChillC")]
        public int WindChillC { get; set; }

        [JsonProperty("WindChillF")]

        public int WindChillF { get; set; }

        [JsonProperty("WindGustMiles")]

        public int WindGustMiles { get; set; }

        [JsonProperty("WindGustKmph")]

        public int WindGustKmph { get; set; }

        [JsonProperty("FeelsLikeC")]
        public int FeelsLikeC { get; set; }

        [JsonProperty("FeelsLikeF")]

        public int FeelsLikeF { get; set; }

        [JsonProperty("chanceofrain")]

        public int Chanceofrain { get; set; }

        [JsonProperty("chanceofremdry")]

        public int Chanceofremdry { get; set; }

        [JsonProperty("chanceofwindy")]

        public int Chanceofwindy { get; set; }

        [JsonProperty("chanceofovercast")]

        public int Chanceofovercast { get; set; }

        [JsonProperty("chanceofsunshine")]

        public int Chanceofsunshine { get; set; }

        [JsonProperty("chanceoffrost")]

        public int Chanceoffrost { get; set; }

        [JsonProperty("chanceofhightemp")]

        public int Chanceofhightemp { get; set; }

        [JsonProperty("chanceoffog")]

        public int Chanceoffog { get; set; }

        [JsonProperty("chanceofsnow")]

        public int Chanceofsnow { get; set; }

        [JsonProperty("chanceofthunder")]

        public int Chanceofthunder { get; set; }

        [JsonProperty("uvIndex")]

        public int UvIndex { get; set; }
    }
}
