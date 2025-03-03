using System;
using System.Collections.Generic;

namespace PracticeWebsite.Models;

public partial class Quiz
{
    public int QuizId { get; set; }

    public int SubjectId { get; set; }

    public int KeystageId { get; set; }

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual Subject Subject { get; set; } = null!;
}
