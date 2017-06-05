using ProjectCinderella.Data.Repositories;

namespace ProjectCinderella.Data.Components.CrudComponents
{
	public class EditEntityComponent
	{
		public void Execute<T>(IRepository<T> repo, T entity) where T : class => repo.Edit(entity);
	}
}