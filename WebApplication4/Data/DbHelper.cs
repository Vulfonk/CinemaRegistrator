using CinemaDB.Data;
using CinemaDB.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace WebApplication4.Data
{
    public class DbHelper
    {

        public IEnumerable<JsonSession> GetSessions(DateTime currentTime)
        {
            using DbCinemaContext context = new DbCinemaContext();

            var dtHelper = new DateTimeHelper();

            var sessionsList = context.Sessions
                .Select(s => new JsonSession(
                        s.DateTime, s.FilmNavigation.Name, s.Film,
                        s.Tickets.Where(t => t.IsSold == 0).Count(),
                        s.HallNavigation.Number))
                .ToList()
                .Where(s => dtHelper.DateTimeInRange(s.StartTime, currentTime, 4));

            return sessionsList;

        }


    }

    public class JsonSession
    {
        public DateTime StartTime { get; set;}        
        public string FilmName { get; set;}
        public int FilmID { get; }
        public int AvailiblePlaces { get; set;}
        public int HallNumber { get; set;}


        public JsonSession(string startStr, string film, int availiblePlaces, int filmId, int hallNum)
        {
            StartTime = new DateTimeHelper().ParseDateTime(startStr);
            FilmName = film;
            FilmID = filmId;
            AvailiblePlaces = availiblePlaces;
            HallNumber = hallNum;
        }

    }

    public class DateTimeHelper
    {
        public bool DateTimeInRange(DateTime curDate, DateTime refDate, int hoursHalfRange)
        {
            return Math.Abs((curDate - refDate).TotalHours) < hoursHalfRange;
        }

        public DateTime ParseDateTime(string dateString)
        {
            string format = "yyyy-MM-dd HH:mm";

            return DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        }
    }

}
