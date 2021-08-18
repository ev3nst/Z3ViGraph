using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using ViGraph.Models;
using ViGraph.Models.DTO;
using ViGraph.Database;
using ViGraph.Repository.IRepository;
using ViGraph.Utility.Config;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using System.Text.Json;
using System;

namespace ViGraph.Repository
{

	public class AppUserRepository : Repository<AppUser, AppUserDTO>, IAppUserRepository
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

		public override string ActionsHTML(AppUserDTO User)
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

		public override void CheckButtonPermissions()
		{
			var editPermission = _context.HttpContext.User.Claims.Where(c => c.Type == "Permission" && c.Value == "AppUser.Edit");
			UseEditButton = editPermission.Any();

			var deletePermission = _context.HttpContext.User.Claims.Where(c => c.Type == "Permission" && c.Value == "AppUser.Delete");
			UseEditButton = deletePermission.Any();
		}

		public override async Task<IEnumerable<AppUserDTO>> Paginate(PaginationOptions paginationOptions)
		{
			CheckButtonPermissions();
			var mainQuery = _db.AppUser
			.Include(u => u.UserRole)
			.ThenInclude(u => u.Role)
            .Select(u => new AppUserDTO {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                CreatedAt = u.CreatedAt,
                DeletedAt = u.DeletedAt,
                RoleName = u.UserRole.Role.Name,
                RoleSef = u.UserRole.Role.Sef
            })
			.Where(
				u => u.DeletedAt == null && u.Email != AppConfig.RootCredentials.Email
			);

			if (paginationOptions.SortOrder == SortOrderTypes.ASC) {
				mainQuery = mainQuery.OrderBy(u => EF.Property<object>(u, paginationOptions.SortField));
			} else {
				mainQuery = mainQuery.OrderByDescending(u => EF.Property<object>(u, paginationOptions.SortField));
			}

			int TotalCount = await mainQuery.CountAsync();
			var data = await mainQuery
			.Skip(paginationOptions.Offset)
			.Take(paginationOptions.PerPage)
			.AsNoTracking()
			.AsSplitQuery()
			.ToListAsync();

			for (int i = 0; i < data.Count; i++) {
				data[i].ActionsHTML = ActionsHTML(data[i]);
			}

			return data;
		}
	}
}
