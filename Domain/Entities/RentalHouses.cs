using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class RentalHouse
{
    public int IdPublication { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public bool StatusRent { get; set; }

    public string WhoElse { get; set; } = null!;

    public long RentPrice { get; set; }

    public string TypeHouse { get; set; } = null!;

    public int? IdRentalHouseDetail { get; set; }

    public DateTime PublicationDate { get; set; }

    public int? IdLocation { get; set; }

    public int? IdHouseService { get; set; }

    public int? IdUser { get; set; }

    public virtual HouseService? IdHouseServiceNavigation { get; set; }

    public virtual Location? IdLocationNavigation { get; set; }

    public virtual RentalHouseDetail? IdRentalHouseDetailNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Image> Image { get; set; } = new List<Image>();

    public virtual ICollection<Report> Report { get; set; } = new List<Report>();

    public virtual ICollection<Request> Request { get; set; } = new List<Request>();

    public virtual ICollection<Report> IdReport { get; set; } = new List<Report>();
}
