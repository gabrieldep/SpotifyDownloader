using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyDownloader.Model
{
    public class SpotifyDownloaderDbContext : AppLogger.Model.DbContext
    {
        public DbSet<Music> Musics { get; set; }

        public SpotifyDownloaderDbContext()
        {
        }

        public SpotifyDownloaderDbContext(DbContextOptions<SpotifyDownloaderDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
