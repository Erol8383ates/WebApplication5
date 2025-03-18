using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Printer> Printers { get; set; }

        public DbSet<NetwerkMaterial> NetwerkMaterials { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Beamer> Beamers { get; set; }
    }
  

}
