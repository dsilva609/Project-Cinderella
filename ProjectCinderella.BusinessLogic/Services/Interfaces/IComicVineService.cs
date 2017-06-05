using ProjectCinderella.Model.ComicVineModels;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
	public interface IComicVineService
	{
		ComicVineResult Search(string query);

		Book SearchByID(string id);
	}
}