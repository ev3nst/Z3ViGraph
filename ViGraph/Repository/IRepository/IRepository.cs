using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViGraph.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
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
	}
}
