using System;
using System.Collections.Generic;

namespace CinemaDB.Data.Entities;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Film> FilmGenre1Navigations { get; set; } = new List<Film>();

    public virtual ICollection<Film> FilmGenre2Navigations { get; set; } = new List<Film>();
}
