using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViGraph.ViewModels;

namespace ViGraph.Controllers
{
	public class IndexController : Controller
	{
        [Authorize]
		public IActionResult Index()
		{
			return Json(new
			{
				status = "Ok",
				message = "This is index controller"
			});
		}

        [HttpGet("/error")]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
