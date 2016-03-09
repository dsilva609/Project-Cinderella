using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLogic.Repositories
{
	public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext, new()
	{
		private readonly DbContext _context;
		private readonly Dictionary<Type, object> _repositories;
		private bool _isDisposed;

		public UnitOfWork()
		{
			this._context = new TContext();
			this._repositories = new Dictionary<Type, object>();
			this._isDisposed = false;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this._isDisposed)
			{
				if (disposing)
				{
					this._context.Dispose();
				}

				this._isDisposed = true;
			}
		}

		public IRepository<TContext> GetRepository<TContext>() where TContext : class
		{
			if (this._repositories.Keys.Contains(typeof(TContext)))
				return this._repositories[typeof(TContext)] as IRepository<TContext>;

			var repository = new Repository<TContext>(this._context);
			this._repositories.Add(typeof(TContext), repository);
			return repository;
		}

		public void SaveChanges()
		{
			this._context.SaveChanges();
			this._context.Dispose();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~UnitOfWork()
		{
			this._context.Dispose();
		}
	}
}