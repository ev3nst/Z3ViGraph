using System.Threading.Tasks;
using System.Linq;

using ViGraph.Models;
using ViGraph.Database;
using ViGraph.Repository.IRepository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ViGraph.Repository
{
	public class AppUserRepository : Repository<AppUser>, IAppUserRepository
	{
		private readonly ApplicationDbContext _db;

		private readonly IHttpContextAccessor _context;

		private readonly LinkGenerator _generator;

		public AppUserRepository(ApplicationDbContext db, IHttpContextAccessor context, LinkGenerator generator) : base(db, context, generator)
		{
			_db = db;
			_context = context;
			_generator = generator;
		}

		public override string EditLink(int Id)
		{
			return _generator.GetPathByName(Routes.EditUser, new { Id = Id });
		}

		public override string DeleteLink(int Id)
		{
			return _generator.GetPathByName(Routes.DeleteUser, new { Id = Id });
		}

		public override string ActionsHTML(AppUser User)
		{
			var EditHTML = (UseEditButton == true) ? CreateEditButton(User.Id) : "";
			var DeleteHTML = (UseDeleteButton == true) ? CreateDeleteButton(User.Id, User.FullName) : "";

			return @"
            <span style='overflow: visible; position: relative; width: 130px;'>
                " + EditHTML + @"
                " + DeleteHTML + @"
            </span>
            ";
		}

        public override void CheckButtonPermissions() {
            foreach (var xx in _context.HttpContext.User.Claims.Where(c => c.Type == "Permission"))
            {
                System.Console.WriteLine(xx);
            }


            return;
        }
	}
}
