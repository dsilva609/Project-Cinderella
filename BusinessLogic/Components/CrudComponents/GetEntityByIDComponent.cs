using BusinessLogic.Repositories;

namespace BusinessLogic.Components.CrudComponents
{
    public class GetEntityByIDComponent
    {
        public T Execute<T>(IRepository<T> repo, int id) where T : class
        {
            return repo.GetByID(id);
        }
    }
}