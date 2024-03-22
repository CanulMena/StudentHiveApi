namespace StudentHive.Domain.Dtos;

public class publicationUserDto
{
    public int IdPublication { get; set; }
    public string Title { get; set; } = null!;
    public DateTime PublicationDate { get; set; }
    public bool Status { get; set; }
    public string FirstImage { get; set; } = null!;

}