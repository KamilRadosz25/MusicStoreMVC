using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MvcMusicStore.Models
{
    public class MusicStoreEntities : DbContext
    {
        public MusicStoreEntities(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .Property(a => a.Title)
                .IsRequired();
            modelBuilder.Entity<Genre>()
                .Property(x => x.Description)
                .IsRequired(false);

        }


    }
}
