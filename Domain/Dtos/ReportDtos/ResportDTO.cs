namespace StudentHive.Domain.Dtos;

public class ReportDTO
{
    public int IdReport { get; set; }
    public int IdReportType { get; set; }
    public virtual ReportTypeDTO IdReportTypeNavigation { get; set; } = null!;
    public virtual ICollection<RentalHouseDto> IdPublication { get; set; } = new List<RentalHouseDto>();
}