using CinemaDB.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("infoReserved")]
    public class InfoReferedController : ControllerBase
    {
        [HttpGet(Name = "infoReserved")]
        public AvailibleSeats Get(int sessionId)
        {
            var helper = new DbHelper();
            return helper.GetSessionById(1);
        }
    }
}
