using StudentHive.Domain.Dtos.Update;

namespace StudentHive.Domain.Dtos;

public class RentalHouseUpdateDto
{
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int RentPrice { get; set; }
        
        // 'IAm', 'Family', 'Other People', 'Companions'
        public string? TypeHouse { get; set; } 

        //'OwnHouse','SharedRoom','SingleRoom'
        public string? WhoElse { get; set; }
        public List<IFormFile?> ImagesFiles { get; set; } = new();
        public virtual HouseLocationUpdateDto? HouseLocation { get; set; }
        public virtual HouseDetailUpdateDto? HouseDetail { get; set; }
        public virtual HouseServiceUpdateDto? HouseServiceUpdateDto { get; set; }
}





