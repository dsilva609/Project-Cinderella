using System;

namespace BusinessLogic.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<TContext> GetRepository<TContext>() where TContext : class;

		void SaveChanges();
	}
}