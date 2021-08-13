using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;

using ViGraph.Models;
using ViGraph.ViewModels;

namespace ViGraph.Controllers
{
	[Route("users")]
	public class UserController : Controller
	{
		UserManager<AppUser> _userManager;
		RoleManager<AppRole> _roleManager;

        private readonly IHtmlLocalizer<AuthController> _localizer;

		public UserController(
			UserManager<AppUser> userManager,
			RoleManager<AppRole> roleManager,
            IHtmlLocalizer<AuthController> localizer
		)
		{
			_userManager = userManager;
			_roleManager = roleManager;
            _localizer = localizer;
		}

		[HttpGet("/")]
		public IActionResult Index()
		{
			return View();
		}
	}
}