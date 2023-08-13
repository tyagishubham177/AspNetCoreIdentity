using Microsoft.AspNetCore.Mvc;

namespace AuthNZ.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly (int Min, int Max, string Summary)[] TemperatureSummaries = new[]
        {
            (-20, -1, "Freezing"),
            (0, 9, "Bracing"),
            (10, 19, "Chilly"),
            (20, 29, "Cool"),
            (30, 39, "Mild"),
            (40, 49, "Warm"),
            (50, 55, "Scorching")
        };

        private readonly Random _rng = new Random();

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => {
                var temperatureC = _rng.Next(-20, 56);
                var summary = TemperatureSummaries.First(s => temperatureC >= s.Min && temperatureC <= s.Max).Summary;

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = temperatureC,
                    Summary = summary
                };
            })
            .ToArray();
        }

        public class WeatherForecast
        {
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
            public string Summary { get; set; }
        }
    }
}