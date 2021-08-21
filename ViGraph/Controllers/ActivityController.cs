using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;

using ViGraph.Models;
using ViGraph.Models.ViewModels;

namespace ViGraph.Controllers
{
	public class ActivityController : Controller
	{
        private readonly IHtmlLocalizer<AuthController> _localizer;

		public ActivityController(
            IHtmlLocalizer<AuthController> localizer
		)
		{
            _localizer = localizer;
		}

		[HttpGet("/activities")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
