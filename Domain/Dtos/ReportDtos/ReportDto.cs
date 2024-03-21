namespace StudentHive.Domain.Dtos;

public class ReportDto
{
    public int IdReport { get; set; }
    public int IdUser { get; set; }
    public int IdPublication { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ReportTypeDto? IdReportType { get; set; }
}