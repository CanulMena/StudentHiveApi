using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Request
{
    public int IdRequest { get; set; }

    public int? IdUser { get; set; }

    public int? IdPublication { get; set; }

    public int? IdEvent { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Event? IdEventNavigation { get; set; }

    public virtual RentalHouse? IdPublicationNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<ReservationConfirmed> ReservationsConfirmed { get; set; } = new List<ReservationConfirmed>();
}
