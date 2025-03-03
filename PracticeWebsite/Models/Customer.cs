﻿using System;
using System.Collections.Generic;

namespace PracticeWebsite.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Postcode { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public bool? Employee { get; set; }

    public string? EmployeeId { get; set; }

    public int? LoyaltyPoints { get; set; }

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();

    public virtual ICollection<Roombooking> Roombookings { get; set; } = new List<Roombooking>();

    public virtual ICollection<Ticketbooking> Ticketbookings { get; set; } = new List<Ticketbooking>();
}
