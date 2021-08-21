using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;

using ViGraph.Models;
using ViGraph.Models.ViewModels;

namespace ViGraph.Controllers
{
	public class PlaylistController : Controller
	{
        private readonly IHtmlLocalizer<AuthController> _localizer;

		public PlaylistController(
            IHtmlLocalizer<AuthController> localizer
		)
		{
            _localizer = localizer;
		}

		[HttpGet("/playlists")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
