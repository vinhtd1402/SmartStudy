using System;
using System.Collections.Generic;

namespace DataAcecss.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public int? SubjectId { get; set; }

    public DateOnly? ExamDate { get; set; }

    public TimeOnly? ExamTime { get; set; }

    public string? ExamRoom { get; set; }

    public virtual Subject? Subject { get; set; }
}
