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

namespace ViGraph.Repository
{

	public class AppUserRepository : Repository<AppUser, AppUserDTO>, IAppUserRepository
	{
		private readonly ApplicationDbContext _db;

		private readonly IHttpContextAccessor _context;

		private readonly LinkGenerator _generator;

		public bool UseRestoreButton { get; set; }

		public bool UsePermaDeleteButton { get; set; }

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

		public string RestoreLink(int Id)
		{
			return _generator.GetPathByName(Routes.RestoreUser, new { Id = Id });
		}

		public string PermaDeleteLink(int Id)
		{
			return _generator.GetPathByName(Routes.PermaDeleteUser, new { Id = Id });
		}


		public string CreateRestoreButton(int Id)
		{
			return @"
            <a
                class='btn btn-sm btn-default btn-text-primary btn-hover-primary btn-icon restore-button'
                href='javascript:;'
                data-toggle='modal'
                data-target='#restoreConfirmation'
                data-restore-link='" + RestoreLink(Id) + @"'
                title='Restore'>
                <span class='svg-icon svg-icon-md'>
                    <svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                        <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                            <rect x='0' y='0' width='24' height='24'/>
                            <path d='M12,8 L8,8 C5.790861,8 4,9.790861 4,12 L4,13 C4,14.6568542 5.34314575,16 7,16 L7,18 C4.23857625,18 2,15.7614237 2,13 L2,12 C2,8.6862915 4.6862915,6 8,6 L12,6 L12,4.72799742 C12,4.62015048 12.0348702,4.51519416 12.0994077,4.42878885 C12.264656,4.2075478 12.5779675,4.16215674 12.7992086,4.32740507 L15.656242,6.46136716 C15.6951359,6.49041758 15.7295917,6.52497737 15.7585249,6.56395854 C15.9231063,6.78569617 15.876772,7.09886961 15.6550344,7.263451 L12.798001,9.3840407 C12.7118152,9.44801079 12.607332,9.48254921 12.5,9.48254921 C12.2238576,9.48254921 12,9.25869158 12,8.98254921 L12,8 Z' fill='#000000'/>
                            <path d='M12.0583175,16 L16,16 C18.209139,16 20,14.209139 20,12 L20,11 C20,9.34314575 18.6568542,8 17,8 L17,6 C19.7614237,6 22,8.23857625 22,11 L22,12 C22,15.3137085 19.3137085,18 16,18 L12.0583175,18 L12.0583175,18.9825492 C12.0583175,19.2586916 11.8344599,19.4825492 11.5583175,19.4825492 C11.4509855,19.4825492 11.3465023,19.4480108 11.2603165,19.3840407 L8.40328311,17.263451 C8.18154548,17.0988696 8.13521119,16.7856962 8.29979258,16.5639585 C8.32872576,16.5249774 8.36318164,16.4904176 8.40207551,16.4613672 L11.2591089,14.3274051 C11.48035,14.1621567 11.7936615,14.2075478 11.9589099,14.4287888 C12.0234473,14.5151942 12.0583175,14.6201505 12.0583175,14.7279974 L12.0583175,16 Z' fill='#000000' opacity='0.3'/>
                        </g>
                    </svg>
                </span>
            </a>
			";
		}

		public string CreatePermaDeleteButton(int Id, string Title)
		{
			return @"
            <a
            class='btn btn-sm btn-default btn-text-danger btn-hover-danger btn-icon perma-delete-button'
            href='javascript:;'
            data-toggle='modal'
            data-target='#permaDeleteConfirmation'
            data-title='" + Title + @"'
            data-delete-link='" + PermaDeleteLink(Id) + @"'
            title='Delete'>
                <span class='svg-icon svg-icon-md'>
                    <svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                        <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                            <rect x='0' y='0' width='24' height='24'/>
                            <path d='M6,8 L18,8 L17.106535,19.6150447 C17.04642,20.3965405 16.3947578,21 15.6109533,21 L8.38904671,21 C7.60524225,21 6.95358004,20.3965405 6.89346498,19.6150447 L6,8 Z M8,10 L8.45438229,14.0894406 L15.5517885,14.0339036 L16,10 L8,10 Z' fill='#000000' fill-rule='nonzero'/>
                            <path d='M14,4.5 L14,3.5 C14,3.22385763 13.7761424,3 13.5,3 L10.5,3 C10.2238576,3 10,3.22385763 10,3.5 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424,6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z' fill='#000000' opacity='0.3'/>
                        </g>
                    </svg>
                </span>
            </a>
			";
		}


		public override string ActionsHTML(AppUserDTO User)
		{
			var EditHTML = (UseEditButton == true) ? CreateEditButton(User.Id) : "";
			var DeleteHTML = (UseDeleteButton == true) ? CreateDeleteButton(User.Id, User.FullName) : "";
			var RestoreHTML = (UseEditButton == true) ? CreateRestoreButton(User.Id) : "";
			var PermaDeleteHTML = (UseDeleteButton == true) ? CreatePermaDeleteButton(User.Id, User.FullName) : "";

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
			.Select(u => new AppUserDTO
			{
				Id = u.Id,
				FullName = u.FullName,
				Email = u.Email,
				CreatedAt = u.CreatedAt,
				DeletedAt = u.DeletedAt,
				RoleName = u.UserRole.Role.Name,
				RoleSef = u.UserRole.Role.Sef
			})
			.Where(u => u.DeletedAt == null && u.Email != AppConfig.RootCredentials.Email);

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

		public async Task<IEnumerable<AppUserDTO>> PaginateDeleted(PaginationOptions paginationOptions)
		{
			CheckButtonPermissions();
			var mainQuery = _db.AppUser
			.Include(u => u.UserRole)
			.ThenInclude(u => u.Role)
			.Select(u => new AppUserDTO
			{
				Id = u.Id,
				FullName = u.FullName,
				Email = u.Email,
				CreatedAt = u.CreatedAt,
				DeletedAt = u.DeletedAt,
				RoleName = u.UserRole.Role.Name,
				RoleSef = u.UserRole.Role.Sef
			})
			.Where(u => u.DeletedAt != null);

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
