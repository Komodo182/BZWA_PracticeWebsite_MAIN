﻿using System;
using System.Collections.Generic;

namespace PracticeWebsite.Models;

public partial class Attraction
{
    public int AttractionId { get; set; }

    public string? AttractionName { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
