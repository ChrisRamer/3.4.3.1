using System.Collections.Generic;

namespace MusicDatabase.Models
{
	public class Genre
	{
		public int GenreId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<GenreSong> Songs { get; set; }

		public Genre()
		{
			this.Songs = new HashSet<GenreSong>();
		}
	}
}