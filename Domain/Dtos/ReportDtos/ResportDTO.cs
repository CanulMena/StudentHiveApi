namespace StudentHive.Domain.Dtos;

public class ReportDTO
{
    public virtual ReportTypeDTO IdReportTypeNavigation { get; set; } = null!;
    public string? TypeReportName { get; set; }

}