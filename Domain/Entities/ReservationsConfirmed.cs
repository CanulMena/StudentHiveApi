using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class ReservationConfirmed
{
    public int IdRerservation { get; set; }

    public int? IdRequest { get; set; }

    public DateTime RerservationDate { get; set; }

    public virtual Request? IdRequestNavigation { get; set; }
}
