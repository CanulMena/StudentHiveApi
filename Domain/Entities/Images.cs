using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Image
{
    public int IdImage { get; set; }

    public string UrlImageHouse { get; set; } = null!;

    public int? IdPublication { get; set; }

    public virtual RentalHouse? IdPublicationNavigation { get; set; }
}
