using System.Linq;
using ProjectCinderella.Data.Repositories;

namespace ProjectCinderella.Data.Components.CrudComponents
{
	public class GetEntityListComponent
	{
		public IQueryable<T> Execute<T>(IRepository<T> repo) where T : class
		{
			return repo.GetAll();
		}
	}
}