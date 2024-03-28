namespace StudentHive.Domain.Dtos;

public class ReportDto
{
    public int IdReport { get; set; }
    //nombre de usuario, correo
    // imagen de la publicacion, titulo, fecha en la que creo la publicacion
    public virtual UserReportDto? IdUserNavigation { get; set; }
    public virtual PublicationReportDto? IdPublicationNavigation { get; set; }
    public DateTime CreatedAt { get; set; }
    public int IdReportType { get; set; }
    public string? TypeReportName { get; set; }
}