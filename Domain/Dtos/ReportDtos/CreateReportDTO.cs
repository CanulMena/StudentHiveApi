namespace StudentHive.Domain.Dtos;

public class CreateRreportDTO
{
    public int IdTypeReport { get; set; }

     public string? TypeReportName { get; set; }

    public int IdRentalHouse { get; set; }

    public int IdUser { get; set; }
}
