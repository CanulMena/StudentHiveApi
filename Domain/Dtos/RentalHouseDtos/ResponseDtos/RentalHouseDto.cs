namespace StudentHive.Domain.Dtos;

public class RentalHouseDto
{ /* It's just for transferring data */
        public int IdPublication { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Status { get; set; }

        public string WhoElse { get; set; } = null!;

        public long RentPrice { get; set; }

        public string TypeHouse { get; set; } = null!;

        public int? IdRentalHouseDetail { get; set; }

        public DateTime PublicationDate { get; set; }

        public int? IdLocation { get; set; }

        public int? IdHouseService { get; set; }

        public virtual HouseServiceDto? IdHouseServiceNavigation { get; set; }

        public virtual HouseLocationDto? IdLocationNavigation { get; set; }
        
        public virtual UserDTO? IdUserNavigation { get; set; }

        public virtual RentalHouseDetailDto? IdRentalHouseDetailNavigation { get; set; }

        public virtual List<ImageRentalHouseDto> Images { get; set; } = new ();
        
}




