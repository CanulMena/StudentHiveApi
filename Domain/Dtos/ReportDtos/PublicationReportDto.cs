namespace StudentHive.Domain.Dtos;
    public class PublicationReportDto
    {
        public int IdPublication { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public DateTime PublicationDate { get; set; }
    }
