namespace MusicDatabase.Models
{
	public class GenreSong
	{
		public int GenreSongId { get; set; }
		public int SongId { get; set; }
		public int GenreId { get; set; }
		public virtual Genre Genre { get; set; }
		public virtual Song Song { get; set; }
	}
}