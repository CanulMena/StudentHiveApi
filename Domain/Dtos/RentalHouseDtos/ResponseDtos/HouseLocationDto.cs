
namespace StudentHive.Domain.Dtos;


public class HouseLocationDto
    {
        public int IdLocation { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Neighborhood  { get; set; } = null!;
    }