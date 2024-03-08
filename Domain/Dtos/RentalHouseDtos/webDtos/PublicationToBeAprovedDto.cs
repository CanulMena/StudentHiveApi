namespace StudentHive.Domain.Dtos;

public class PublicationToBeAprovedDto
{
    public int IdPublication { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Images { get; set; } = null!;
    public DateTime dateTime { get; set; }
    public virtual WebLocationDtos? WebLocationDtos {get; set;}
    public virtual WebUserDtos? WebUser { get; set; }
}