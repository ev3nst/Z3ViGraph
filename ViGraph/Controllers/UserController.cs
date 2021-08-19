using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Authorization;

using ViGraph.Models;
using ViGraph.Utility;
using ViGraph.ViewModels;
using ViGraph.Repository.IRepository;

namespace ViGraph.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		UserManager<AppUser> _userManager;

		RoleManager<AppRole> _roleManager;

		IAppUserRepository _appUserRepo;

		IAppRoleRepository _appRoleRepo;

		private readonly IHtmlLocalizer<AuthController> _localizer;

		public UserController(
			UserManager<AppUser> userManager,
			RoleManager<AppRole> roleManager,
			IAppUserRepository appUserRepo,
			IAppRoleRepository appRoleRepo,
			IHtmlLocalizer<AuthController> localizer
		)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_appUserRepo = appUserRepo;
			_appRoleRepo = appRoleRepo;
			_localizer = localizer;
		}

		[HttpGet]
		[Route(Routes.ListUsersPath, Name = Routes.ListUsers)]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[Route(Routes.ListUsersApiPath, Name = Routes.ListUsersApi)]
		public async Task<IActionResult> IndexApi(PaginationOptions paginationOptions)
		{
			var response = await _appUserRepo.Paginate(paginationOptions);
			response.status = "success";
			response.statusCode = 200;
			response.message = "API returned with successfull data.";
			return Json(response);
		}

		[HttpGet]
		[Route(Routes.ListUsersTrashApiPath, Name = Routes.ListUsersTrashApi)]
		public async Task<IActionResult> IndexTrashApi(PaginationOptions paginationOptions)
		{
			var response = await _appUserRepo.PaginateDeleted(paginationOptions);
			response.status = "success";
			response.statusCode = 200;
			response.message = "API returned with successfull data.";
			return Json(response);
		}

		[HttpGet]
		[Route(Routes.EditUserPath, Name = Routes.EditUser)]
		public async Task<IActionResult> EditUser()
		{
			return Json(new
			{
				Ok = 1
			});
		}


		[HttpDelete]
		[ValidateAntiForgeryToken]
		[Route(Routes.DeleteUserPath, Name = Routes.DeleteUser)]
		public async Task<IActionResult> DeleteUser()
		{
			return Json(new
			{
				Ok = 1
			});
		}
	}
}
