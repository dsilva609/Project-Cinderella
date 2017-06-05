using System.Collections.Generic;
using System.Linq;

namespace ProjectCinderella.Data.Repositories
{
	public interface IRepository<T>
	{
		void Add(T entity);

		IQueryable<T> GetAll();

		T GetByID(int? id, string userID);

		void Edit(T entity);

		void Edit(IEnumerable<T> entities);

		void Delete(int id, string userID);

		int GetCount();
	}
}