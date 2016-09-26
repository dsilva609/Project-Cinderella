using BusinessLogic.Repositories;
using System.Linq;

namespace BusinessLogic.Components.CrudComponents
{
	public class GetEntityListComponent
	{
		public IQueryable<T> Execute<T>(IRepository<T> repo) where T : class
		{
			return repo.GetAll();
		}
	}
}