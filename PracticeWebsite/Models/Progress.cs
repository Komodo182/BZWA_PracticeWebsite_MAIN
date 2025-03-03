using System;
using System.Collections.Generic;

namespace PracticeWebsite.Models;

public partial class Progress
{
    public int CustomerId { get; set; }

    public int Ks1Maths { get; set; }

    public int QuizId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Quiz Quiz { get; set; } = null!;
}
