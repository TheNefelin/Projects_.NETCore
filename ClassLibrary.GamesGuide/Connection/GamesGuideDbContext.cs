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
        public DbSet<GuideUserEntity> GG_GuidesUser { get; set; }
        public DbSet<AdventureEntity> GG_Adventures { get; set; }
        public DbSet<AdventureUserEntity> GG_AdventuresUser { get; set; }
        public DbSet<AdventureImgEntity> GG_AdventuresImg { get; set; }

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
                t.Property(e => e.Url).HasColumnType("VARCHAR(256)");
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

            modelBuilder.Entity<GuideUserEntity>(t =>
            {
                t.HasKey(c => new { c.Id_Guide, c.Id_User });
                t.Property(c => c.Id_User).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.Guide)
                    .WithMany(tr => tr.GuidesUser)
                    .HasForeignKey(c => c.Id_Guide)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AdventureEntity>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Description).HasColumnType("VARCHAR(800)");
                t.HasOne(tr => tr.Guide)
                    .WithMany(tr => tr.Adventures)
                    .HasForeignKey(c => c.Id_Guide)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AdventureUserEntity>(t =>
            {
                t.HasKey(c => new { c.Id_Adventure, c.Id_User });
                t.HasOne(tr => tr.Adventure)
                    .WithMany(tr => tr.AdventuresUser)
                    .HasForeignKey(c => c.Id_Adventure)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AdventureImgEntity>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.ImgUrl).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.Adventure)
                    .WithMany(tr => tr.AdventuresImg)
                    .HasForeignKey(c => c.Id_Adventure)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
