using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViGraph.Models;

namespace ViGraph.Repository.IRepository
{
	public interface IRepository<T> : IUsesPagination<T> where T : class
	{
		#region Basic CRUD
		// Basic
		Task<T> Find(int id);

		Task<T> Add(T entity);

		Task<T> Update(T entity);

		void Remove(T entity);

		void RemoveRange(IEnumerable<T> entity);

		Task<T> FirstOrDefault(
			Expression<Func<T, bool>> filter = null,
			string includeProperties = null,
			bool isTracking = true
		);

		Task<IEnumerable<T>> GetAll(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = null,
			bool isTracking = true
		);
		#endregion

		#region Get Current User
		string GetCurrentUserName();

		int GetCurrentUserId();

		Task<AppUser> GetByUserId(int UserId);

		Task<AppUser> GetByUserIdWithRoles(int UserId);

		Task<AppUser> GetCurrentUser();

		Task<AppUser> GetCurrentUserWithRoleClaims();
		#endregion
	}
}
