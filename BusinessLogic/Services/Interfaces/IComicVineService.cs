using BusinessLogic.Models;
using BusinessLogic.Models.ComicVineModels;

namespace BusinessLogic.Services.Interfaces
{
	public interface IComicVineService
	{
		ComicVineResult Search(string query);

		Book SearchByID(string id);
	}
}