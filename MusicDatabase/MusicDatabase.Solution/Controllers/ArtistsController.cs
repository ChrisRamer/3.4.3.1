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

		private Artist GetArtistFromId(int id)
		{
			return _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
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

		public ActionResult Details(int id)
		{
			Artist thisArtist = _db.Artists
				.Include(artist => artist.Songs)
				.ThenInclude(join => join.Song)
				.FirstOrDefault(artist => artist.ArtistId == id);
			return View(thisArtist);
		}

		public ActionResult Edit(int id)
		{
			Artist thisArtist = GetArtistFromId(id);
			return View(thisArtist);
		}

		[HttpPost]
		public ActionResult Edit(Artist artist)
		{
			_db.Entry(artist).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = artist.ArtistId });
		}
	}
}