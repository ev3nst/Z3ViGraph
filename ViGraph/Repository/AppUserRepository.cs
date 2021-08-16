using ViGraph.Models;
using ViGraph.Database;
using ViGraph.Repository.IRepository;

using Microsoft.AspNetCore.Http;

namespace ViGraph.Repository
{
	public class AppUserRepository : Repository<AppUser>, IAppUserRepository
	{
		private readonly ApplicationDbContext _db;

		private readonly IHttpContextAccessor _context;

		public AppUserRepository(ApplicationDbContext db, IHttpContextAccessor context) : base(db, context)
		{
			_db = db;
		}
	}
}
