using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;
using ViGraph.Database;
using ViGraph.Repository.IRepository;

namespace ViGraph.Repository
{
	public abstract class Repository<T, TDTO> : IRepository<T, TDTO> where T : class
	{
		private readonly ApplicationDbContext _db;

		private readonly IHttpContextAccessor _context;

		private readonly LinkGenerator _generator;

		internal DbSet<T> dbSet;

		public bool UseEditButton { get; set; } = true;

		public bool UseDeleteButton { get; set; } = true;

		public Repository(ApplicationDbContext db, IHttpContextAccessor context, LinkGenerator generator)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
			_context = context;
			_generator = generator;
		}

		#region Basic CRUD
		public async Task<T> Find(int id)
		{
			return await dbSet.FindAsync(id);
		}

		public async Task<T> Add(T entity)
		{
			await dbSet.AddAsync(entity);
			await _db.SaveChangesAsync();
			return entity;
		}

		public async Task<T> Update(T entity)
		{
			dbSet.Update(entity);
			await _db.SaveChangesAsync();
			return entity;
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}

		public async Task<T> FirstOrDefault(
			Expression<Func<T, bool>> filter = null,
			string includeProperties = null,
			bool isTracking = true
		)
		{
			IQueryable<T> query = dbSet;
			if (filter != null) {
				query = query.Where(filter);
			}
			if (includeProperties != null) {
				foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
					query = query.Include(includeProp);
				}
			}
			if (!isTracking) {
				query = query.AsNoTracking();
			}
			return await query.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<T>> GetAll(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = null, bool isTracking = true
		)
		{
			IQueryable<T> query = dbSet;
			if (filter != null) {
				query = query.Where(filter);
			}
			if (includeProperties != null) {
				foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
					query = query.Include(includeProp);
				}
			}
			if (orderBy != null) {
				query = orderBy(query);
			}
			if (!isTracking) {
				query = query.AsNoTracking();
			}
			return await query.ToListAsync();
		}
		#endregion

		#region Get Current User
		public string GetCurrentUserName()
		{
			return _context.HttpContext.User.Identity.Name;
		}

		public int GetCurrentUserId()
		{
			return int.Parse(_context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
		}

		public async Task<AppUser> GetUserById(int UserId)
		{
			return await _db.AppUser.OrderBy(u => u.Id).AsNoTracking().FirstOrDefaultAsync(u => u.Id == UserId);
		}

		public async Task<AppUser> GetUserByIdWithRoles(int UserId)
		{
			return await _db.AppUser.Include(u => u.UserRole).ThenInclude(u => u.Role).ThenInclude(r => r.RoleClaims).OrderBy(u => u.Id).AsSplitQuery().AsNoTracking().FirstOrDefaultAsync(u => u.Id == UserId);
		}

		public async Task<AppUser> GetCurrentUser()
		{
			var loggedInUserId = _context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
			return await _db.AppUser.OrderBy(u => u.Id).AsNoTracking().FirstOrDefaultAsync(u => u.Id == GetCurrentUserId());
		}

		public async Task<AppUser> GetCurrentUserWithRoleClaims()
		{
			var loggedInUserId = _context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
			return await _db.AppUser.Include(u => u.UserRole).ThenInclude(u => u.Role).ThenInclude(r => r.RoleClaims).OrderBy(u => u.Id).AsSplitQuery().AsNoTracking().FirstOrDefaultAsync(u => u.Id == GetCurrentUserId());
		}
		#endregion

		#region Pagination
		public abstract string EditLink(int Id);

		public abstract string DeleteLink(int Id);

		public string CreateEditButton(int Id)
		{
			return @"
            <a
                class='btn btn-sm btn-default btn-text-primary btn-hover-primary btn-icon mr-2 edit-button'
                data-id='" + EditLink(Id) + @"'
                href='" + EditLink(Id) + @"' title='Edit'>
                <span class='svg-icon svg-icon-md'>
                    <svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                        <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                            <rect x='0' y='0' width='24' height='24'></rect>
                            <path d=M12.2674799,18.2323597 L12.0084872,5.45852451 C12.0004303,5.06114792 12.1504154,4.6768183 12.4255037,4.38993949 L15.0030167,1.70195304 L17.5910752,4.40093695 C17.8599071,4.6812911 18.0095067,5.05499603 18.0083938,5.44341307 L17.9718262,18.2062508 C17.9694575,19.0329966 17.2985816,19.701953 16.4718324,19.701953 L13.7671717,19.701953 C12.9505952,19.701953 12.2840328,19.0487684 12.2674799,18.2323597 Z' fill='#000000' fill-rule='nonzero' transform='translate(14.701953, 10.701953) rotate(-135.000000) translate(-14.701953, -10.701953) '></path>							<path d='M12.9,2 C13.4522847,2 13.9,2.44771525 13.9,3 C13.9,3.55228475 13.4522847,4 12.9,4 L6,4 C4.8954305,4 4,4.8954305 4,6 L4,18 C4,19.1045695 4.8954305,20 6,20 L18,20 C19.1045695,20 20,19.1045695 20,18 L20,13 C20,12.4477153 20.4477153,12 21,12 C21.5522847,12 22,12.4477153 22,13 L22,18 C22,20.209139 20.209139,22 18,22 L6,22 C3.790861,22 2,20.209139 2,18 L2,6 C2,3.790861 3.790861,2 6,2 L12.9,2 Z' fill='#000000' fill-rule='nonzero' opacity='0.3'></path>
                        </g>
                    </svg>
                </span>
            </a>
			";
		}

		public string CreateDeleteButton(int Id, string Title)
		{
			return @"
            <a
            class='btn btn-sm btn-default btn-text-danger btn-hover-danger btn-icon delete-button'
            href='javascript:;'
            data-toggle='modal'
            data-target='#deleteConfirmation'
            data-title='" + Title + @"'
            data-delete-link='" + DeleteLink(Id) + @"'
            title='Delete'>
                <span class='svg-icon svg-icon-md'>
                    <svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                        <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                            <polygon points='0 0 24 0 24 24 0 24'/>
                            <path d='M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z' fill='#000000' fill-rule='nonzero' opacity='0.3'/>
                            <path d='M10.5857864,13 L9.17157288,11.5857864 C8.78104858,11.1952621 8.78104858,10.5620972 9.17157288,10.1715729 C9.56209717,9.78104858 10.1952621,9.78104858 10.5857864,10.1715729 L12,11.5857864 L13.4142136,10.1715729 C13.8047379,9.78104858 14.4379028,9.78104858 14.8284271,10.1715729 C15.2189514,10.5620972 15.2189514,11.1952621 14.8284271,11.5857864 L13.4142136,13 L14.8284271,14.4142136 C15.2189514,14.8047379 15.2189514,15.4379028 14.8284271,15.8284271 C14.4379028,16.2189514 13.8047379,16.2189514 13.4142136,15.8284271 L12,14.4142136 L10.5857864,15.8284271 C10.1952621,16.2189514 9.56209717,16.2189514 9.17157288,15.8284271 C8.78104858,15.4379028 8.78104858,14.8047379 9.17157288,14.4142136 L10.5857864,13 Z' fill='#000000'/>
                        </g>
                    </svg>
                </span>
            </a>
			";
		}

		public abstract string ActionsHTML(TDTO Resource);

		public abstract void CheckButtonPermissions();

		public abstract Task<IEnumerable<TDTO>> Paginate(PaginationOptions PaginationOptions);
		#endregion
	}
}
