namespace StudentHive.Domain.Dtos;

public class RentalHouseUpdateDTO{ /* It's just for transferring data */
        public int Idpublication { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int RentPrice { get; set; }
        public List<IFormFile?> ImagesFiles { get; set; } = new();
        public required RentalHouseDetailDTO DetailRentalHouse { get; set; }
        public DateTime PublicationDate { get; set; }
        public HouseLocationDTO HouseLocation { get; set; } = null!;
        public HouseServiceDTO Service { get; set; } = null!;
        public string IdUser { get; set; } = null!;
}





