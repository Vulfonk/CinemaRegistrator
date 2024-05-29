using CinemaDB.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("bookSeat")]
    public class BookSeatController : ControllerBase
    {
        [HttpPost(Name = "bookSeat")]
        public void Post(SeatInfo info)
        {
            /*var helper = new DbHelper();
            helper.SeatPlace(info.session, info.place);*/
        }

        public class SeatInfo
        {
            public int place { get; set; }
            public int session { get; set; }

        }
    }



}
