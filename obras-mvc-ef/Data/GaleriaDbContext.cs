using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using obras_mvc_ef.Models;

namespace obras_mvc_ef.Data
{
    public class GaleriaDbContext : IdentityDbContext
    {
        public GaleriaDbContext(DbContextOptions options) : base(options) { } 
        
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Obras> Obras { get; set; }
        public DbSet<Exposicion> Exposiciones { get; set; }

        //arreglo de db:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tener cuidado cuando ya se uso el Onmodelcrating
            //El problema sera solucionado si se agrega la siguiente linea
            base.OnModelCreating(modelBuilder);
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
