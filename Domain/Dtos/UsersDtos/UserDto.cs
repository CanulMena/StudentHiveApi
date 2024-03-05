using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;

public class UserDTO
{
    public int IdUser { get; set; }
    public int? UserAge { get; set; }
    public string Email { get; set; } = null!;
    // public string Password { get; set; } = null!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Description { get; set; }
    public long? PhoneNumber { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public byte? Genderu { get; set; }
    // public string? Token { get; set; }
    public int? IdRol { get; set; }
    public virtual List<UserRentalHouseDTO> RentalHouses { get; set; } = new();
}