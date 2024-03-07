using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class PublicationWithReportDTO
{
    public int IdPublication { get; set; }
    public string Title { get; set; } = null!;
    public string NameofUser {get; set;} = null!;
    public List<string> Image_Url_P { get; set; } = null!;
    // public long RentPrice { get; set; }
    public DateTime PublicationDate { get; set; }
    public int IdReport { get; set; }
    public string TypeReportName { get; set; } = null!;
}
