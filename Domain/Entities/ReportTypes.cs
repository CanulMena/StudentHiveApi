using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class ReportType
{
    public int IdTypeReport { get; set; }

    public string? TypeReportName { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
