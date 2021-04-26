using System.Collections.Generic;

namespace MusicDatabase.Models
{
	public class Artist
	{
		public int ArtistId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<GenreSong> Songs { get; set; }

		public Artist()
		{
			this.Songs = new HashSet<GenreSong>();
		}
	}
}