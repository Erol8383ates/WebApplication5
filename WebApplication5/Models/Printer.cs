using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Printer
    {
        [Key]
        public int Id { get; set; }

      
        public string? Naam { get; set; }

        public string? Lokaal { get; set; }

        public string? Ipaddress { get; set; }

        public string? Model { get; set; }

        public string? Opmerkingen { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;  // Default to current time if not provided
    }
}
