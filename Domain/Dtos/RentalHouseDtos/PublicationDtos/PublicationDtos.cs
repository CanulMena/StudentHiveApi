namespace StudentHive.Domain.Dtos;

public class PublicationDtos
{
    public int IdPublication { get; set; }
    public string Title { get; set; } = null!;
    public string NameofUser {get; set;} = null!;
    public List<string> Images { get; set; } = null!;
    public long RentPrice { get; set; }
    public DateTime PublicationDate { get; set; }
}