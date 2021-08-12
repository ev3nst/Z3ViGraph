using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using ViGraph.Database.Repository.IRepository;

namespace ViGraph.Database.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
		}

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
	}
}
