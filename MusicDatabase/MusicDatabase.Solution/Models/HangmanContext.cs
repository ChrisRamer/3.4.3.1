using Microsoft.EntityFrameworkCore;

namespace MusicDatabase.Models
{
	public class MusicDatabaseContext : DbContext
	{
		//public virtual DbSet<XXXXX> YYYYY { get; set; }
		//public virtual DbSet<XXXXX> YYYYY { get; set; }

		public MusicDatabaseContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}