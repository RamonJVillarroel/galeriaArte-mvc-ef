using Microsoft.EntityFrameworkCore;
using obras_mvc_ef.Models;

namespace obras_mvc_ef.Data
{
    public class GaleriaDbContext : DbContext
    {
        public GaleriaDbContext(DbContextOptions options) : base(options) { } 
        
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Obras> Obras { get; set; }
        public DbSet<Exposicion> Exposiciones { get; set; }

        //arreglo de db:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exposicion>().HasData(
                new Exposicion
                {
                    Id= 1,
                    Nombre = "Expo especial",
                    FechaInicio = Convert.ToDateTime("10/10/2025"),
                    FechaFin = Convert.ToDateTime("30/10/2025")
                }
                );
        }
    }
}
