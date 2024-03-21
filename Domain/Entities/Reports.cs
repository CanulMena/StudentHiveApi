﻿using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Report
{
    public int IdReport { get; set; }

    public int IdReportType { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? IdPublication { get; set; }

    public int? IdUser { get; set; }

    public virtual RentalHouse? IdPublication1 { get; set; }

    public virtual ReportType IdReportTypeNavigation { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<RentalHouse> IdPublicationNavigation { get; set; } = new List<RentalHouse>();
}