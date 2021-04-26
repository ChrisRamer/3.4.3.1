using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MusicDatabase.Models
{
	public class MusicDatabaseContextFactory : IDesignTimeDbContextFactory<MusicDatabaseContext>
	{

		MusicDatabaseContext IDesignTimeDbContextFactory<MusicDatabaseContext>.CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			  .SetBasePath(Directory.GetCurrentDirectory())
			  .AddJsonFile("appsettings.json")
			  .Build();

			var builder = new DbContextOptionsBuilder<MusicDatabaseContext>();
			string connectionString = configuration.GetConnectionString("DefaultConnection");

			builder.UseMySql(connectionString);

			return new MusicDatabaseContext(builder.Options);
		}
	}
}