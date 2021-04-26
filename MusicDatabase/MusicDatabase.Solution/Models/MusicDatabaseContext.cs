using Microsoft.EntityFrameworkCore;

namespace MusicDatabase.Models
{
	public class MusicDatabaseContext : DbContext
	{
		public virtual DbSet<Genre> Genres { get; set; }
		public virtual DbSet<Song> Songs { get; set; }
		public virtual DbSet<Artist> Artists { get; set; }
		public virtual DbSet<GenreSong> GenreSong { get; set; }
		public virtual DbSet<ArtistSong> ArtistSong { get; set; }

		public MusicDatabaseContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}