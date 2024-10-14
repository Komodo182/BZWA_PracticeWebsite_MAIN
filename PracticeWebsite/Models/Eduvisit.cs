using System;
using System.Collections.Generic;

namespace PracticeWebsite.Models;

public partial class Eduvisit
{
    public string? SchoolName { get; set; }

    public string? StageOfEdu { get; set; }

    public DateOnly? DayOfVisit { get; set; }

    public int? QuantityOfStudents { get; set; }

    public int? QuantityOfStaff { get; set; }
}
