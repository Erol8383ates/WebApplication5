namespace WebApplication5.Models
{
    public class PrinterDto
    {
        public int Id { get; set; }
        public string? Naam { get; set; }
        public string? Lokaal { get; set; }
        public string? Ipaddress { get; set; }
        public string? Model { get; set; }

        public string? Opmerkingen { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
