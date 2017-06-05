using ProjectCinderella.Data.Repositories;

namespace ProjectCinderella.Data.Components.CrudComponents
{
    public class DeleteEntityComponent
    {
        public void Execute<T>(IRepository<T> repo, int id, string userID) where T : class => repo.Delete(id, userID);
    }
}