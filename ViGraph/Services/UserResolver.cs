using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using ViGraph.Models;
using ViGraph.Database.Repository.IRepository;

namespace ViGraph.Services
{

	public class UserResolver
	{
		private readonly IHttpContextAccessor _context;
		private readonly IAppUserRepository _appUserRepo;
		public UserResolver(IHttpContextAccessor context, IAppUserRepository appUserRepo)
		{
			_context = context;
			_appUserRepo = appUserRepo;
		}

		public string GetCurrentUserName()
		{
			return _context.HttpContext.User.Identity.Name;
		}

		public int GetCurrentUserId()
		{
			return int.Parse(_context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
		}

		public async Task<AppUser> GetCurrentUser()
		{
			var loggedInUserId = _context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
			return await _appUserRepo.Find(GetCurrentUserId());
		}
	}
}
