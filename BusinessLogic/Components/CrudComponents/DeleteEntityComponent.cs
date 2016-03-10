using BusinessLogic.Repositories;

namespace BusinessLogic.Components.CrudComponents
{
    public class DeleteEntityComponent
    {
        public void Execute<T>(IRepository<T> repo, int id) where T : class
        {
            repo.Delete(id);
        }
    }
}