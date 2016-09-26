using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Repositories
{
	public interface IRepository<T>
	{
		void Add(T entity);

		IQueryable<T> GetAll();

		T GetByID(int? id, string userID);

		void Edit(T entity);

		void Edit(List<T> entities);

		void Delete(int id, string userID);

		int GetCount();
	}
}