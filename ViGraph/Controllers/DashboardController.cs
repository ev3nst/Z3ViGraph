using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViGraph.Models;
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

            var paginationOptions = new PaginationOptions<AppUser> {
                PerPage = 10,
                Page = 1,
                SortField = "FullName",
                SortOrder = SortOrderTypes.ASC,
            };

            _appUseRepository.Paginate(paginationOptions);

			return View();
		}
	}
}
