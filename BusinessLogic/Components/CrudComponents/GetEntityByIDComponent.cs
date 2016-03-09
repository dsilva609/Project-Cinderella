using BusinessLogic.Repositories;

namespace BusinessLogic.Components.CrudComponents
{
	public class GetEntityByIDComponent
	{
		public T Execute<T>(IRepository<T> repo, int ID) where T : class
		{
			return repo.GetByID(ID);
		}
	}
}