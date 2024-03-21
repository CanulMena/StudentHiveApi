using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class RentalHouseDetail
{
    public int IdRentalHouseDetail { get; set; }

    public int? NumberOfGuests { get; set; }

    public int? NumberOfBathrooms { get; set; }

    public int? NumberOfRooms { get; set; }

    public int? NumbersOfBed { get; set; }

    public int? NumberOfHammocks { get; set; }

    public virtual RentalHouse? RentalHouse { get; set; }
}
