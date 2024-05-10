using CinemaDB.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<JsonSession> Get(string date)
        {
            var helper = new DbHelper();
            return helper.GetSessions(DateTime.Parse(date));
        }
    }
}
