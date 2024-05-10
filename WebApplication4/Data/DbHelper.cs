using CinemaDB.Data;
using CinemaDB.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace WebApplication4.Data
{
    public class DbHelper
    {
        public string GetSessions(DateTime currentTime)
        {
            using DbCinemaContext context = new DbCinemaContext();

            var sessionsList = context.Sessions
                ?.Select(s => new OSession() { FilmName = s.FilmNavigation.Name, StartTimeStr = s.DateTime })
                ?.ToList()
                ?.Where(s => DateTimeInRange(ParseDateTime(s.StartTimeStr), currentTime))
                ?.Select(s => s.FilmName + "\t" + s.StartTimeStr);

            return sessionsList?.Any() == true 
                ? string.Join("\n", sessionsList) 
                : "Empty";

        }

        private bool DateTimeInRange(DateTime curDate, DateTime refDate)
        {
            return Math.Abs((curDate - refDate).TotalHours) < 4; 

                
        }

        private DateTime ParseDateTime(string dateString)
        {
            string format = "yyyy-MM-dd HH:mm";

            return DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        }

    }

    public class OSession
    {

        public DateTime StartTime { get; set;}
        public string StartTimeStr { get; set; }
        public string FilmName { get; set;}

    }

}
