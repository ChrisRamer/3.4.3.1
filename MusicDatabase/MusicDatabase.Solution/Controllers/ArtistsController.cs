using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MusicDatabase.Models;

namespace MusicDatabase.Controllers
{
	public class ArtistsController : Controller
	{
		private readonly MusicDatabaseContext _db;

		public ArtistsController(MusicDatabaseContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			List<Artist> model = _db.Artists.ToList();
			return View(model);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Artist artist)
		{
			_db.Artists.Add(artist);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}