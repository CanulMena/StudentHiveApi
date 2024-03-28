namespace StudentHive.Domain.Dtos.QueryFilters;

//Fecha que se publica, tipo de reporte

public class QueryReport
{
    public string? TypeReportName { get; set; }
    public int IdUser { get; set; }
    public int IdPublication { get; set; }
    public int IdTypeReport { get; set; }
    public DateTime? BelowDatePublication { get; set; }
    public DateTime? OverDatePublication { get; set; }

}