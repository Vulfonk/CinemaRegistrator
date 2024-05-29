using CinemaDB.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NearestSessionsController : ControllerBase
    {
        private readonly ILogger<NearestSessionsController> _logger;

        public NearestSessionsController(ILogger<NearestSessionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetNearestSessions")]
        public IEnumerable<JsonSession> Get(string date)
        {
            var helper = new DbHelper();
            if(date.Last() == '\'')
                date = date.Remove(date.Length - 1);
            return helper.GetSessions(DateTime.Parse(date));
        }
    }
}
