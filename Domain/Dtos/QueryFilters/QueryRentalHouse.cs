namespace StudentHive.Domain.Dtos.QueryFilters;

//por fecha, precio de ascendente y desendente, ubicacion, tipo de casa, servicios
public class QueryRentalHouse
{
    public string? WhoElse { get; set; }
    public DateTime? BelowDatePublication { get; set; }
    public DateTime? OverDatePublication { get; set; }
    public decimal? BelowPrice { get; set; }
    public decimal? OverPrice { get; set; }
    public string? TypeHouse { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; } 
    public string? State { get; set; } 
    public string? Country { get; set; } 
    public int PostalCode { get; set; }
    public bool Wifi { get; set; }
    public bool Kitchen { get; set; }
    public bool Washer { get; set; }
    public bool AirConditioning { get; set; }
    public bool Water { get; set; }
    public bool Gas { get; set; }
    public bool Television { get; set; }
    public int? NumberOfGuests { get; set; }
    public int? NumberOfBathrooms { get; set; }
    public int? NumberOfRooms { get; set; }
    public int? NumbersOfBed { get; set; }
    public int? NumberOfHammocks { get; set; }
}