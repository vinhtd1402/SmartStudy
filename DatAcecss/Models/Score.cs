using System;
using System.Collections.Generic;

namespace DataAcecss.Models;

public partial class Score
{
    public int ScoreId { get; set; }

    public int? SubjectId { get; set; }

    public string? TestName { get; set; }

    public double? Score1 { get; set; }

    public virtual Subject? Subject { get; set; }
}
