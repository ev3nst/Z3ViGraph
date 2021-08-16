using ViGraph.Models;
using ViGraph.Database;
using ViGraph.Repository.IRepository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

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

        public async override Task CheckButtonPermissions() {
            var currentUser = await GetCurrentUser();
            System.Console.WriteLine("Check button permissions?");
            System.Console.WriteLine(currentUser.Role.RoleClaims);

            return;
        }
	}
}
