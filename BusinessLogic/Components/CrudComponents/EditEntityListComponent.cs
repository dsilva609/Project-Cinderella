using BusinessLogic.Repositories;
using System.Collections.Generic;

namespace BusinessLogic.Components.CrudComponents
{
	public class EditEntityListComponent
	{
		public void Execute<T>(IRepository<T> repo, List<T> entity) where T : class
		{
			repo.Edit(entity);
		}
	}
}