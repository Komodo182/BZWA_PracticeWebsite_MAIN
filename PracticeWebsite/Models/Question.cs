using System;
using System.Collections.Generic;

namespace PracticeWebsite.Models;

public partial class Question
{
    public int QuestionsId { get; set; }

    public string Question1 { get; set; } = null!;

    public string Answer1 { get; set; } = null!;

    public string Answer2 { get; set; } = null!;

    public string Answer3 { get; set; } = null!;

    public string Answer4 { get; set; } = null!;

    public string Finalanswer { get; set; } = null!;

    public int QuizId { get; set; }

    public virtual Quiz Quiz { get; set; } = null!;
}
