using System.Text.Json;
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

            var paginationOptions = new PaginationOptions {
                PerPage = 10,
                Page = 1,
                SortField = "FullName",
                SortOrder = SortOrderTypes.ASC,
            };

           var data = await _appUseRepository.Paginate(paginationOptions);


     return Json(data, new JsonSerializerOptions
    {
        WriteIndented = true,
    });

			// return View();
		}
	}
}
