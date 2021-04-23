using Microsoft.AspNetCore.Mvc;

namespace XXXXX.Controllers
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