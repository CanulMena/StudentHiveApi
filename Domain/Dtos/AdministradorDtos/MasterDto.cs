
using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos.AdminDtos;

public class MasterDto
{
    public int IdAdmin { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    // public int? IdRol { get; set; }
    public string? NombreRol { get; set; }
}