using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViGraph.Models;

namespace ViGraph.Controllers
{
    [Authorize]
	public class DashboardController : Controller
	{

        [HttpGet("/dashboard")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
