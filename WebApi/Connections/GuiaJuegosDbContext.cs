using ClassLibrary.GuiaJuegos.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Connections
{
    public class GuiaJuegosDbContext : DbContext
    {
        public GuiaJuegosDbContext(DbContextOptions<GuiaJuegosDbContext> options) : base(options)
        {
        }

        public DbSet<GJJuegoEntity> GJ_Juegos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GJJuegoEntity>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(50)");
                t.Property(c => c.Descripcion).HasColumnType("VARCHAR(256)");
                t.Property(c => c.ImgUrl).HasColumnType("VARCHAR(256)");
            });

        }
    }
}
