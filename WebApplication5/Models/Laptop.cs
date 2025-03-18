namespace WebApplication5.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        public string? Lokaal { get; set; } = "";

        public string? Laptopcar { get; set; } = "";
        public string? Ram { get; set; } = "";
        public string? Naam { get; set; } = "";
        public string? MerkModel { get; set; } = "";
        public string? CPU { get; set; } = "";
        public string? Vlan { get; set; } = "";
        public string? Ipaddress { get; set; } = "";
        public string? Opmerkingen { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
