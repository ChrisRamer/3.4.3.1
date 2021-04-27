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
	}
}