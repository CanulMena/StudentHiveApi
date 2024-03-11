namespace StudentHive.Domain.Dtos;

public class RentalHouseCreateDto
{ 
        public int IdUser { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string WhoElse { get; set; } = null!;
        public long RentPrice { get; set; }
        public string TypeHouse { get; set; } = null!;
        public RentalHouseDetailCreateDto DetailRentalHouse { get; set; } = null!;
        public HouseServiceCreateDto HouseService { get; set; } = null!;
        public HouseLocationCreateDto HouseLocation { get; set; } = null!;
        public List<IFormFile?> ImagesFiles { get; set; } = [];
}





