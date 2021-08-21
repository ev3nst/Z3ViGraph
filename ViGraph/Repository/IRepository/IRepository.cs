using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViGraph.Models;

namespace ViGraph.Repository.IRepository
{
	public interface IRepository<T, TDTO> : IUsesPagination<T, TDTO> where T : class
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

        Task Save();
		#endregion

		#region Get Current User
		string GetCurrentUserName();

		int GetCurrentUserId();

		Task<AppUser> GetUserById(int UserId);

		Task<AppUser> GetUserByIdWithRoles(int UserId);

		Task<AppUser> GetCurrentUser();

		Task<AppUser> GetCurrentUserWithRoleClaims();
		#endregion
	}
}
