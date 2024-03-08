namespace StudentHive.Domain.Dtos;

public class RepotedPublicationDtos
{
    public int IdPublication { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Images { get; set; } = null!;
    public DateTime DateTimeOfTheReport { get; set; }
    public List<int>? IdReport { get; set; }
    // public virtual ReportDtos? ReportDtos { get; set; }
    public virtual TypeReportDto? TypeReport { get; set; }
    public virtual WebUserDtos? WebUser { get; set; }

}