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
	}
}