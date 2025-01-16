using ClassLibrary.GamesGuide.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.GamesGuide.Connection
{
    public class GamesGuideDbContext : DbContext
    {
        public GamesGuideDbContext(DbContextOptions<GamesGuideDbContext> options) : base(options)
        {
        }

        public DbSet<GameEntity> GG_Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameEntity>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Name).HasColumnType("VARCHAR(50)");
                t.Property(c => c.Description).HasColumnType("VARCHAR(256)");
                t.Property(c => c.ImgUrl).HasColumnType("VARCHAR(256)");
            });

        }
    }
}
