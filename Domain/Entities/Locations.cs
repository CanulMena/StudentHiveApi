using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Location
{
    public int IdLocation { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int PostalCode { get; set; }

    public string? Neighborhood { get; set; }

    public virtual RentalHouse? RentalHouse { get; set; }
}
