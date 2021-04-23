using Microsoft.EntityFrameworkCore;

namespace Hangman.Models
{
	public class HangmanContext : DbContext
	{
		//public virtual DbSet<XXXXX> YYYYY { get; set; }
		//public virtual DbSet<XXXXX> YYYYY { get; set; }

		public HangmanContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}