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
	}
}