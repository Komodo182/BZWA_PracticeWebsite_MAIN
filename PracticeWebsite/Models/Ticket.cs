using System;
using System.Collections.Generic;

namespace PracticeWebsite.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public DateOnly? ValidDate { get; set; }

    public int? AttractionId { get; set; }

    public virtual Attraction? Attraction { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
