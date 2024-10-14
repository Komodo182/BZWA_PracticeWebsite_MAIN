using System;
using System.Collections.Generic;

namespace PracticeWebsite.Models;

public partial class Room
{
    public int RoomNumber { get; set; }

    public int? Capacity { get; set; }

    public string? RoomType { get; set; }

    public bool? Vacancy { get; set; }

    public bool? DisabilityAccesible { get; set; }

    public virtual ICollection<Roombooking> Roombookings { get; set; } = new List<Roombooking>();
}
