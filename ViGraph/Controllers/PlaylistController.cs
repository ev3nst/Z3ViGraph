using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;

using ViGraph.Models;
using ViGraph.ViewModels;

namespace ViGraph.Controllers
{
	[Route("playlists")]
	public class PlaylistController : Controller
	{
        private readonly IHtmlLocalizer<AuthController> _localizer;

		public PlaylistController(
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
