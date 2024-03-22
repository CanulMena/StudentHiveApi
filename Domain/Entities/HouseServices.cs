using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class HouseService
{
    public int IdHouseService { get; set; }

    public bool? Wifi { get; set; }

    public bool? Kitchen { get; set; }

    public bool? Washer { get; set; }

    public bool? AirConditioning { get; set; }

    public bool? Water { get; set; }

    public bool? Gas { get; set; }

    public bool? Television { get; set; }

    public virtual RentalHouse? RentalHouses { get; set; }
}
