using System;
using System.Collections.Generic;

namespace CinemaDB.Data.Entities;

public partial class Session
{
    public int Id { get; set; }

    public int Film { get; set; }

    public string DateTime { get; set; } = null!;

    public int Hall { get; set; }

    public virtual Film FilmNavigation { get; set; } = null!;

    public virtual Hall HallNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
