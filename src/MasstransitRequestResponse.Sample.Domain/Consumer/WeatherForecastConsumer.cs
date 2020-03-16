using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MasstransitRequestResponse.Sample.Domain.MessageContracts;

namespace MasstransitRequestResponse.Sample.Domain.Consumer
{
    public class WeatherForecastConsumer : IConsumer<WeatherForecastRequest>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public Task Consume(ConsumeContext<WeatherForecastRequest> context)
        {
            var t = Task.Run(async () =>
            {
                var rng = new Random();
                var rs = context.Message.Range.Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                });

                await context.RespondAsync<WeatherForecastResult>(new WeatherForecastResult() { WeatherForecast = rs });

            });

            t.Wait();

            return t;
        }
    }
}