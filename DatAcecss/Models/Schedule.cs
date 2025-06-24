using System;
using System.Collections.Generic;

namespace DataAcecss.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int? SubjectId { get; set; }

    public string? WeekDay { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? Location { get; set; }

    public virtual Subject? Subject { get; set; }
}
