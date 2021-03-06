using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using WeatherGetter.Utilities;

namespace WeatherGetter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeatherGetter", Version = "v1" });
            });

            services.AddCronJob<WeatherCronService>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"0 6 * * *";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMemoryCache cache, ILogger<WeatherCronService> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherGetter v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            WeatherRequestsHandler.GetWeatherForecast(cache, logger);
        }
    }
}
