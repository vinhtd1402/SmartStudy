using System;
using System.Collections.Generic;

namespace DataAcecss.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public int? Credit { get; set; }

    public string? Lecturer { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
