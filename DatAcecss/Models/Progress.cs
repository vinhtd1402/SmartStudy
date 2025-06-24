using System;
using System.Collections.Generic;

namespace DataAcecss.Models;

public partial class Progress
{
    public int ProgressId { get; set; }

    public int? SubjectId { get; set; }

    public string? Topic { get; set; }

    public bool? IsCompleted { get; set; }

    public string? Note { get; set; }

    public virtual Subject? Subject { get; set; }
}
