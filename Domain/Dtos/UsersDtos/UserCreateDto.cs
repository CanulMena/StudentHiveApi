using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;
//all the i need to create an user
public class UserCreateDTO {
    public string? Email { get; set; }
    public string? Password { get; set; } 
    public string? Name { get; set; }
    
}   