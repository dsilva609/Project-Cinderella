using ProjectCinderella.Data.Repositories;

namespace ProjectCinderella.Data.Components.CrudComponents
{
    public class GetEntityByIDComponent
    {
        public T Execute<T>(IRepository<T> repo, int id, string userID) where T : class => repo.GetByID(id, userID);
    }
}