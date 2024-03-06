namespace StudentHive.Domain.Dtos;

public class RentalHouseUpdateDto{ /* It's just for transferring data */
        public int Idpublication { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int RentPrice { get; set; }
        public List<IFormFile?> ImagesFiles { get; set; } = new();
        public required RentalHouseDetailDto DetailRentalHouse { get; set; }
        public DateTime PublicationDate { get; set; }
        public HouseLocationDto HouseLocation { get; set; } = null!;
        public HouseServiceDto Service { get; set; } = null!;
        public string IdUser { get; set; } = null!;
}





