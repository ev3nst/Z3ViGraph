using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ViGraph.Models.ViewModels;
using ViGraph.Repository.IRepository;

namespace ViGraph.Controllers
{
	public class IndexController : Controller
	{
		private readonly IAppUserRepository _appUserRepo;

		public IndexController(IAppUserRepository appUserRepo)
		{
			_appUserRepo = appUserRepo;
		}

		[Authorize]
		[Route("/")]
		public async Task<IActionResult> Index()
		{
			var currentUser = await _appUserRepo.GetCurrentUserWithRoleClaims();
			var permissionClaims = currentUser.UserRole.Role.RoleClaims.Where(c => c.ClaimType == "Permission");
			var PossibleRedirects = new string[4] {
				"Dashboard",
				"Video",
				"AppFile",
				"AppUser"
			};

			for (int i = 0; i < PossibleRedirects.Count(); i++) {
				if (permissionClaims.Where(c => c.ClaimValue == PossibleRedirects[i] + ".View").Any()) {
					return RedirectToAction("Index", PossibleRedirects[i]);
				}
			}

			return Json(currentUser.UserRole.Role.RoleClaims.Where(c => c.ClaimType == "Permission"));
		}

		[HttpGet("/error")]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
