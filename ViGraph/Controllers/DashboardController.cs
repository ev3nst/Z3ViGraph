using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ViGraph.Repository.IRepository;

namespace ViGraph.Controllers
{
    [Authorize]
	public class DashboardController : Controller
	{

		IAppUserRepository _appUseRepository;
		public DashboardController(
			IAppUserRepository appUseRepository
		)
		{
			_appUseRepository = appUseRepository;
		}


        [HttpGet("/dashboard")]
		public async Task<IActionResult> Index()
		{

            await _appUseRepository.CheckButtonPermissions();
			return View();
		}
	}
}
