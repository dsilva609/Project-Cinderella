using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DbContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(DbContext context)
		{
			this._context = context;
			this._dbSet = context.Set<T>();
		}

		public virtual void Add(T entity)
		{
			this._dbSet.Add(entity);
			this._context.SaveChanges();
		}

		public virtual void Delete(int id)
		{
			var entry = this._dbSet.Find(id);
			this._dbSet.Remove(entry);
			this._context.SaveChanges();
		}

		public List<T> GetAll()
		{
			return this._dbSet.ToList();
		}

		public T GetByID(int? id)
		{
			return this._dbSet.Find(id);
		}

		public void Edit(T entity)
		{
			this._context.Entry(entity).State = EntityState.Modified;
			this._context.SaveChanges();
		}

		private IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return this._dbSet.Where(predicate);
		}
	}
}