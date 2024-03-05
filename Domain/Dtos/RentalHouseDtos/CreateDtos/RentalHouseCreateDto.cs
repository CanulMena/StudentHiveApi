namespace StudentHive.Domain.Dtos;

public class RentalHouseCreateDTO{ 
        public int IdUser { get; set; }
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Status { get; set; }

        public string WhoElse { get; set; } = null!;

        public long RentPrice { get; set; }

        public string TypeHouse { get; set; } = null!;
        public RentalHouseDetailCreateDTO DetailRentalHouse { get; set; } = null!;
        public HouseServiceCreateDTO HouseService { get; set; } = null!;
        public HouseLocationCreateDTO HouseLocation { get; set; } = null!;
        public List<IFormFile?> ImagesFiles { get; set; } = [];
}





