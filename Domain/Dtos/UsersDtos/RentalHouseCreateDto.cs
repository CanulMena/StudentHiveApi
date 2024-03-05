namespace StudentHive.Domain.Dtos;

public class RentalHouseCreateDTO{ 
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int RentPrice { get; set; }
        public List<string> Image_Url_P { get; set; } = null!;
        public RentalHouseDetailDTO DetailRentalHouse { get; set; } = null!;
        public HouseServiceDTO HouseService { get; set; } = null!;
        public TypeHouseRentalDTO TypeHouseRental {   get; set; } = null!;
        public HouseLocationDTO HouseLocation { get; set; } = null!;
        public string ID_User { get; set; } = null!;
}





