namespace StudentHive.Domain.Dtos;

public class CreateRequestDto
{
    public int IdUser {get; set;}
    public int IdPublication {get; set;}

    //'Aceptada', 'Rechazada', 'Pendiente'
}