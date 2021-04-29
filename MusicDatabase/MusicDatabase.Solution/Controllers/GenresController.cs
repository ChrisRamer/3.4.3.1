using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MusicDatabase.Models;

namespace MusicDatabase.Controllers
{
	public class GenresController : Controller
	{
		private readonly MusicDatabaseContext _db;

		public GenresController(MusicDatabaseContext db)
		{
			_db = db;
		}

		private Genre GetGenreFromId(int id)
		{
			return _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
		}

		public ActionResult Index()
		{
			List<Genre> model = _db.Genres.ToList();
			return View(model);
		}

		public ActionResult Create()
		{
			ViewBag.SongId = new SelectList(_db.Songs, "SongId", "Name");
			return View();
		}

		[HttpPost]
		public ActionResult Create(Genre genre, int songId)
		{
			_db.Genres.Add(genre);
			if (songId != 0)
			{
				_db.GenreSong.Add(new GenreSong() { SongId = songId, GenreId = genre.GenreId });
			}
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			Genre thisGenre = _db.Genres
				.Include(genre => genre.Songs)
				.ThenInclude(join => join.Song)
				.FirstOrDefault(genre => genre.GenreId == id);
			return View(thisGenre);
		}

		public ActionResult Edit(int id)
		{
			Genre thisGenre = GetGenreFromId(id);
			ViewBag.SongId = new SelectList(_db.Songs, "SongId", "Name");
			return View(thisGenre);
		}

		[HttpPost]
		public ActionResult Edit(Genre genre, int songId)
		{
			bool duplicate = _db.GenreSong.Any(genreSong => genreSong.SongId == songId && genreSong.GenreId == genre.GenreId);
			if (songId != 0 && !duplicate)
			{
				_db.GenreSong.Add(new GenreSong() { SongId = songId, GenreId = genre.GenreId });
			}
			_db.Entry(genre).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = genre.GenreId });
		}

		public ActionResult Delete(int id)
		{
			Genre thisGenre = GetGenreFromId(id);
			return View(thisGenre);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Genre thisGenre =GetGenreFromId(id);
			_db.Genres.Remove(thisGenre);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AddSong(int id)
		{
			Genre thisGenre = GetGenreFromId(id);
			ViewBag.SongId = new SelectList(_db.Songs, "SongId", "Name");
			return View(thisGenre);
		}

		[HttpPost]
		public ActionResult AddSong(Genre genre, int songId)
		{
			bool duplicate = _db.GenreSong.Any(genreSong => genreSong.SongId == songId && genreSong.GenreId == genre.GenreId);
			if (songId != 0 && !duplicate)
			{
				_db.GenreSong.Add(new GenreSong() { SongId = songId, GenreId = genre.GenreId });
			}
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}