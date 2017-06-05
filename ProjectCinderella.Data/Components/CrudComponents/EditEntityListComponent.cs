using System.Collections.Generic;
using ProjectCinderella.Data.Repositories;

namespace ProjectCinderella.Data.Components.CrudComponents
{
	public class EditEntityListComponent
	{
		public void Execute<T>(IRepository<T> repo, List<T> entity) where T : class
		{
			repo.Edit(entity);
		}
	}
}