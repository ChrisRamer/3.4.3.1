using System.Collections.Generic;

namespace MusicDatabase.Models
{
	public class Song
	{
		public int SongId { get; set; }
		public string Name { get; set; }
		public int ArtistId { get; set; }
		public int GenretId { get; set; }
		public virtual ICollection<GenreSong> Genres { get; }

		public Song()
		{
			this.Genres = new HashSet<GenreSong>();
		}
	}
}