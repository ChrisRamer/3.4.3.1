using Microsoft.EntityFrameworkCore;

namespace XXXXX.Models
{
	public class XXXXXContext : DbContext
	{
		//public virtual DbSet<XXXXX> YYYYY { get; set; }
		//public virtual DbSet<XXXXX> YYYYY { get; set; }

		public XXXXXContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}