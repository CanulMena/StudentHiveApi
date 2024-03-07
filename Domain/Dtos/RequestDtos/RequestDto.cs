namespace StudentHive.Domain.Dtos;

public class RequestDto
{
    public int IdRequest {get; set;}
    public int? IdUser {get; set;}
    public int? IdPublication {get; set;}
    //'Aceptada', 'Rechazada', 'Pendiente'
    public string? Status {get; set;}
    public DateTime CreatedAt {get; set;}
}