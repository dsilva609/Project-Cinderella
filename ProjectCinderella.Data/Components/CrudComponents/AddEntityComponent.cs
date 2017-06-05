using ProjectCinderella.Data.Repositories;

namespace ProjectCinderella.Data.Components.CrudComponents
{
	public class AddEntityComponent
	{
		public void Execute<T>(IRepository<T> repo, T entity) where T : class
		{
			repo.Add(entity);
		}
	}
}