using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;

using ViGraph.Models;
using ViGraph.ViewModels;

namespace ViGraph.Controllers
{
	public class CategoryController : Controller
	{
        private readonly IHtmlLocalizer<AuthController> _localizer;

		public CategoryController(
            IHtmlLocalizer<AuthController> localizer
		)
		{
            _localizer = localizer;
		}

		[HttpGet("/categories")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
