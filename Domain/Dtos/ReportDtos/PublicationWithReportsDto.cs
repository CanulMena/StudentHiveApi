namespace StudentHive.Domain.Dtos;

public class PublicationWithReportsDto
{
    public int IdPublication { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public DateTime PublicationDate { get; set; }
    public virtual List<ReportsDto>? Reports { get; set; }
}