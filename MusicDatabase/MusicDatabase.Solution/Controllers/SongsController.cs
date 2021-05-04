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

		public ActionResult Edit(int id)
		{
			Song thisSong = GetSongFromId(id);
			ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
			ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
			return View(thisSong);
		}

		[HttpPost]
		public ActionResult Edit(Song song, int artistId, int genreId)
		{
			bool artistDuplicate = _db.ArtistSong.Any(artistSong => artistSong.ArtistId == artistId && artistSong.SongId == song.SongId);
			bool genreDuplicate = _db.GenreSong.Any(genreSong => genreSong.GenreId == genreId && genreSong.SongId == song.SongId);
			if (artistId != 0 && genreId != 0 && !artistDuplicate && !genreDuplicate)
			{
				_db.ArtistSong.Add(new ArtistSong() { ArtistId = artistId, SongId = song.SongId });
				_db.GenreSong.Add(new GenreSong() { GenreId = genreId, SongId = song.SongId });
			}
			_db.Entry(song).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = song.SongId });
		}

		public ActionResult Delete(int id)
		{
			Song thisSong = GetSongFromId(id);
			return View(thisSong);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Song thisSong = GetSongFromId(id);
			_db.Songs.Remove(thisSong);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}