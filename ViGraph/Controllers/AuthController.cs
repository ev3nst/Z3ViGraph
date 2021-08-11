using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViGraph.Models;

namespace ViGraph.Controllers
{
    [Route("auth")]
	public class AuthController : Controller
	{
        [HttpGet("login")]
		public IActionResult Login()
		{
			return View();
		}

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
		public IActionResult LoginProcess()
		{
			return View();
		}
	}
}
