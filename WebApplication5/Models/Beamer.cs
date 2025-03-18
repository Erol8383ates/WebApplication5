using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Beamer
    {
        [Key]
        public int Id { get; set; }

        public string? Lokaal { get; set; } = "";
        public string? MerkModel { get; set; } = "";
        public string? Lamp { get; set; } = "";
        public string? Aansluting { get; set; } = "";
        public string? Opmerkingen { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;


    }
}