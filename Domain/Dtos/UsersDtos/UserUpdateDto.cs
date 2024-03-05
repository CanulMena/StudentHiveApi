using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;

public class UserUpdateDTO 
{ 
    public string? Description { get; set; }

    public long? PhoneNumber { get; set; }

    // public string? ProfilePhotoUrl { get; set; }

    public IFormFile? Image { get; set; }

}