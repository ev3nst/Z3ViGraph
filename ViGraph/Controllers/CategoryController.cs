using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;

using ViGraph.Models;
using ViGraph.ViewModels;

namespace ViGraph.Controllers
{
	[Route("categories")]
	public class CategoryController : Controller
	{
        private readonly IHtmlLocalizer<AuthController> _localizer;

		public CategoryController(
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
