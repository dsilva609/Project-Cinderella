using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ProjectCinderella.Data.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DbContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(DbContext context)
		{
			this._context = context;
			this._dbSet = context.Set<T>();
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public virtual void Add(T entity)
		{
			this._dbSet.Add(entity);
			this._context.SaveChanges();
		}

		public virtual void Delete(int id, string userID)
		{
			var entry = this._dbSet.Find(id);
			this._dbSet.Remove(entry);
			this._context.SaveChanges();
		}

		public IQueryable<T> GetAll() => this._dbSet.AsQueryable();

		public T GetByID(int? id, string userID) => this._dbSet.Find(id);

		public void Edit(T entity)
		{
			//TODO: check that this works, used to be AddOrUpdate
			//this._context.Set<T>().Update(entity)State = EntityState.Modified;
			//var existing = _dbSet.Find(entity);
			//_context.Entry(entity).State = EntityState.Modified;
			_context.Set<T>().Update(entity);
			this._context.SaveChanges();
		}

		public void Edit(IEnumerable<T> entities)
		{
			foreach (var entity in entities)Edit(entity);
		}

		public int GetCount() => this._dbSet.Count();

		private IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => this._dbSet.Where(predicate);
	}
}