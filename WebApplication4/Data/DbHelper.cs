using CinemaDB.Data;
using CinemaDB.Data.Entities;

namespace WebApplication4.Data
{
    public class DbHelper
    {
        public string GetFirstFilmName()
        {
            using DbCinemaContext context = new DbCinemaContext();

            return context.Films.FirstOrDefault().Name;
        }
    }
}
