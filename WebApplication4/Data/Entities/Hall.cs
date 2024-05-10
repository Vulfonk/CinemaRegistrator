using System;
using System.Collections.Generic;

namespace CinemaDB.Data.Entities;

public partial class Hall
{
    public int Number { get; set; }

    public int Id { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
