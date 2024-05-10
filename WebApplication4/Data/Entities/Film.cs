using System;
using System.Collections.Generic;

namespace CinemaDB.Data.Entities;

public partial class Film
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Director { get; set; }

    public int Year { get; set; }

    public int Genre1 { get; set; }

    public int Genre2 { get; set; }

    public int Duration { get; set; }

    public int Country { get; set; }

    public virtual Country CountryNavigation { get; set; } = null!;

    public virtual Director DirectorNavigation { get; set; } = null!;

    public virtual Genre Genre1Navigation { get; set; } = null!;

    public virtual Genre Genre2Navigation { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
