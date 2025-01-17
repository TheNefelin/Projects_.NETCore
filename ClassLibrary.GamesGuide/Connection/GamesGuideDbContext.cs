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
        public DbSet<CharacterEntity> GG_Characters { get; set; }
        public DbSet<SourceEntity> GG_Sources { get; set; }
        public DbSet<BackgroundEntity> GG_Backgrounds { get; set; }
        public DbSet<GuideEntity> GG_Guides { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameEntity>(t =>
            {
                t.HasKey(e => e.Id);
                t.Property(e => e.Name).HasColumnType("VARCHAR(50)");
                t.Property(e => e.Description).HasColumnType("VARCHAR(256)");
                t.Property(e => e.ImgUrl).HasColumnType("VARCHAR(256)");
            });

            modelBuilder.Entity<CharacterEntity>(t =>
            {
                t.HasKey(e => e.Id);
                t.Property(e => e.Name).HasColumnType("VARCHAR(50)");
                t.Property(e => e.Description).HasColumnType("VARCHAR(256)");
                t.Property(e => e.ImgUrl).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.Game)
                    .WithMany(tr => tr.Characters)
                    .HasForeignKey(c => c.Id_Game)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SourceEntity>(t =>
            {
                t.HasKey(e => e.Id);
                t.Property(e => e.Name).HasColumnType("VARCHAR(50)");
                t.Property(e => e.ImgUrl).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.Game)
                    .WithMany(tr => tr.Source)
                    .HasForeignKey(c => c.Id_Game)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BackgroundEntity>(t =>
            {
                t.HasKey(e => e.Id);
                t.Property(e => e.ImgUrl).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.Game)
                    .WithMany(tr => tr.Backgrounds)
                    .HasForeignKey(c => c.Id_Game)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GuideEntity>(t =>
            {
                t.HasKey(e => e.Id);
                t.Property(e => e.Name).HasColumnType("VARCHAR(100)");
                t.HasOne(tr => tr.Game)
                    .WithMany(tr => tr.Guides)
                    .HasForeignKey(c => c.Id_Game)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
