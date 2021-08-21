using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Authorization;

using ViGraph.Models;
using ViGraph.Utility;
using ViGraph.Models.ViewModels;
using ViGraph.Repository.IRepository;

namespace ViGraph.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		UserManager<AppUser> _userManager;

		RoleManager<AppRole> _roleManager;

		private readonly IAppUserRepository _appUserRepo;

		private readonly IAppRoleRepository _appRoleRepo;

		[BindProperty]
		public UserVM UserVM { get; set; }

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
		public async Task<IActionResult> IndexApi([FromQuery] PaginationOptions paginationOptions)
		{
			var response = await _appUserRepo.Paginate(paginationOptions);
			response.status = "success";
			response.statusCode = 200;
			response.message = "API returned with successfull data.";
			return Json(response);
		}

		[HttpGet]
		[Route(Routes.ListUsersTrashApiPath, Name = Routes.ListUsersTrashApi)]
		public async Task<IActionResult> IndexTrashApi([FromQuery] PaginationOptions paginationOptions)
		{
			var response = await _appUserRepo.PaginateDeleted(paginationOptions);
			response.status = "success";
			response.statusCode = 200;
			response.message = "API returned with successfull data.";
			return Json(response);
		}

		[HttpGet]
		[Route(Routes.EditUserPath, Name = Routes.EditUser)]
		public async Task<IActionResult> Edit(int Id)
		{
			var userVM = new UserVM
			{
				AppUser = await _appUserRepo.Find(Id),
				Roles = await _appRoleRepo.GetAll()
			};

			return View(userVM);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route(Routes.UpdateUserPath, Name = Routes.UpdateUser)]
		public async Task<IActionResult> Update()
		{
			if (ModelState.IsValid) {
				if (string.IsNullOrEmpty(UserVM.Password.Trim()) == false) {
					if (UserVM.Password.Trim() != UserVM.PasswordConfirm.Trim()) {
						ModelState.AddModelError("PasswordConfirm", _localizer.GetString("password_confirm_match"));
						return View("Edit", UserVM);
					}
				}

				await _appUserRepo.Update(UserVM.AppUser);
			}

			return Json(UserVM.AppUser);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route(Routes.DeleteUserPath, Name = Routes.DeleteUser)]
		public async Task<IActionResult> Delete()
		{
			return Json(new
			{
				Ok = 1
			});
		}
	}
}
