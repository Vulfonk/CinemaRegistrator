using System;
using System.Collections.Generic;

namespace CinemaDB.Data.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public int Session { get; set; }

    public string DateTimePurchase { get; set; } = null!;

    public int Place { get; set; }

    public int Row { get; set; }

    public virtual Session SessionNavigation { get; set; } = null!;
}
