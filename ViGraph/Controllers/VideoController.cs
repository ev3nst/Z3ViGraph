using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;

using ViGraph.Models;
using ViGraph.ViewModels;

namespace ViGraph.Controllers
{
	[Route("videos")]
	public class VideoController : Controller
	{
        private readonly IHtmlLocalizer<AuthController> _localizer;

		public VideoController(
            IHtmlLocalizer<AuthController> localizer
		)
		{
            _localizer = localizer;
		}

		[HttpGet("/")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
