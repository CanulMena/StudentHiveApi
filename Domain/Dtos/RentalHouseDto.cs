namespace StudentHive.Domain.Dtos;

public class RentalHouseDTO{ /* It's just for transferring data */
        public int ID_Publication { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int RentPrice { get; set; }
        public List<string> Image_Url_P { get; set; } = null!;
        public required RentalHouseDetailDTO DetailRentalHouse { get; set; }
        public TypeHouseRentalDTO TypeHouseRental { get; set; } = null!;
        public DateTime PublicationDate { get; set; }
        public LocationDTO Location { get; set; } = null!;
        public HouseServiceDTO Service { get; set; } = null!;
        public int ID_User { get; set; }    
}





