namespace StudentHive.Domain.Dtos;

public class ReportDTO
{
    public virtual ReportTypeDTO IdReportTypeNavigation { get; set; } = null!;
    public string? TypeReportName { get; set; }
    public virtual RentalHouseDTO IdPublication { get; set; } = null!;
    public virtual UserDTO? IdUserNavigation { get; set; }
}