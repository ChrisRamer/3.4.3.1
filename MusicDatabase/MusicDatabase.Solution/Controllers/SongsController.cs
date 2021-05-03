using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MusicDatabase.Models;

namespace MusicDatabase.Controllers
{
	public class SongsController : Controller
	{
		private readonly MusicDatabaseContext _db;

		public SongsController(MusicDatabaseContext db)
		{
			_db = db;
		}

		private Song GetSongFromId(int id)
		{
			return _db.Songs.FirstOrDefault(song => song.SongId == id);
		}

		public ActionResult Index()
		{
			List<Song> model = _db.Songs.ToList();
			return View(model);
		}

		public ActionResult Create()
		{
			ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
			ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
			return View();
		}

		[HttpPost]
		public ActionResult Create(Song song, int artistId, int genreId)
		{
			_db.Songs.Add(song);

			if (artistId != 0)
			{
				_db.ArtistSong.Add(new ArtistSong() { ArtistId = artistId, SongId = song.SongId });
			}
			if (genreId != 0)
			{
				_db.GenreSong.Add(new GenreSong() { GenreId = genreId, SongId = song.SongId });
			}

			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			Song thisSong = GetSongFromId(id);
			ViewBag.Artist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == thisSong.ArtistId);
			ViewBag.Genre = _db.Genres.FirstOrDefault(genre => genre.GenreId == thisSong.GenreId);
			return View(thisSong);
		}
	}
}