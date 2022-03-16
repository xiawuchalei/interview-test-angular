using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace interview_test_angular.Mediatr.Forecast
{
    public class GetForcastRequest : IRequest<GetForcastResponse>
    {
    }

    public class GetForcastResponse
    {
        public IEnumerable<WeatherForecast> Forecast { get; set; }
    }

    public class GetForcastHandler : IRequestHandler<GetForcastRequest, GetForcastResponse>
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<GetForcastResponse> Handle(GetForcastRequest request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            var forcast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            var response = new GetForcastResponse { Forecast = forcast };

            return Task.FromResult(response);
        }
    }
}
