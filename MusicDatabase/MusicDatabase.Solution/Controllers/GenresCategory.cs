using Microsoft.AspNetCore.Mvc;
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
			return View();
		}

		[HttpPost]
		public ActionResult Create(Genre genre)
		{
			_db.Genres.Add(genre);
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
			return View(thisGenre);
		}

		[HttpPost]
		public ActionResult Edit(Genre genre)
		{
			_db.Entry(genre).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = genre.GenreId });
		}
	}
}