namespace StudentHive.Domain.Dtos.QueryFilters;

//Fecha que se publica, tipo de reporte

public class QueryReports
{
    public string? TypeReport { get; set; }
    public DateTime? BelowDatePublication { get; set; }
    public DateTime? OverDatePublication { get; set; }
}