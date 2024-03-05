using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;

public class ImageRentalHouseDTO /* It's just for transferring data */
{
    public int IdImage { get; set; }

    public string UrlImageHouse { get; set; } = null!;

}

