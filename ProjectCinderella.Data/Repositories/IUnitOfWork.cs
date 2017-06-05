using System;

namespace ProjectCinderella.Data.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<TContext> GetRepository<TContext>() where TContext : class;

		void SaveChanges();
	}
}