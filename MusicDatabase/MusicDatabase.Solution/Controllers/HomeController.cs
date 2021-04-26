using Microsoft.AspNetCore.Mvc;

namespace MusicDatabase.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet("/")]
		public ActionResult Index()
		{
			return View();
		}
	}
}