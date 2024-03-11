using StudentHive.Domain.Dtos.Update;

namespace StudentHive.Domain.Dtos;

public class RentalHouseUpdateDto
{
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int RentPrice { get; set; }
        
        // 'IAm', 'Family', 'Other People', 'Companions'
        public string TypeHouse { get; set; } = null!;

        //'OwnHouse','SharedRoom','SingleRoom'
        public string WhoElse { get; set; } = null!;
        public List<IFormFile?> ImagesFiles { get; set; } = new();
        public required HouseDetailUpdateDto DetailRentalHouse { get; set; }
        public HouseLocationUpdateDto HouseLocation { get; set; } = null!;
        public HouseServiceUpdateDto Service { get; set; } = null!;
}





