using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using ViGraph.Models;
using ViGraph.ViewModels;

namespace ViGraph.Controllers
{
	[Route("auth")]
	public class AuthController : Controller
	{
		UserManager<AppUser> _userManager;
		SignInManager<AppUser> _signInManager;
		RoleManager<AppRole> _roleManager;

		public AuthController(
			UserManager<AppUser> userManager,
			RoleManager<AppRole> roleManager,
			SignInManager<AppUser> signInManager
		)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
		}

		[HttpGet("login")]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost("login")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LoginPost(LoginVM loginModel)
		{
			if (ModelState.IsValid) {
                System.Console.WriteLine("Sign INING ??  ? ");
				var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
				if (result.Succeeded) {
					return RedirectToAction("Index", "Dashboard");
				}
				ModelState.AddModelError("", "Invalid login attempt");
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
