namespace StudentHive.Domain.Dtos.Update;

public class HouseLocationUpdateDto
{
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Country { get; set; } = null!;
    public int PostalCode { get; set; } 
    public string Neighborhood  { get; set; } = null!;

}