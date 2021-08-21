using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;

using ViGraph.Models;
using ViGraph.Repository.IRepository;
using ViGraph.Models.ViewModels;

namespace ViGraph.Controllers
{
	[Route("auth")]
	public class AuthController : Controller
	{
		UserManager<AppUser> _userManager;

		SignInManager<AppUser> _signInManager;

		RoleManager<AppRole> _roleManager;

		IAppUserRepository _appUseRepository;

		private readonly IHtmlLocalizer<AuthController> _localizer;

		public AuthController(
			UserManager<AppUser> userManager,
			RoleManager<AppRole> roleManager,
			SignInManager<AppUser> signInManager,
			IHtmlLocalizer<AuthController> localizer,
			IAppUserRepository appUseRepository
		)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_localizer = localizer;
			_appUseRepository = appUseRepository;
		}

		[HttpGet]
		[Route(Routes.ShowLoginPath, Name = Routes.ShowLogin)]
		public IActionResult Login()
		{
			if (HttpContext.User.Identity.IsAuthenticated) {
				return RedirectToAction("Index", "Dashboard");
			}

			return View();
		}

		[HttpPost]
		[Route(Routes.LoginPath, Name = Routes.Login)]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginVM loginModel)
		{
			if (ModelState.IsValid) {
				var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
				if (result.Succeeded) {
					if (string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]) == false) {
						return Redirect(HttpContext.Request.Query["ReturnUrl"]);
					} else {
						return RedirectToAction("Index", "Dashboard");
					}
				}
				ModelState.AddModelError("", _localizer.GetString("invalid_login_attempt"));
			}
			return View(loginModel);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login", "Auth");
		}
	}
}
