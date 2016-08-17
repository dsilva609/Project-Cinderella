using BusinessLogic.Models.ComicVineModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface IComicVineService
    {
        ComicVineResult Search(string query);

        ComicVineResult SearchByID(int id);
    }
}