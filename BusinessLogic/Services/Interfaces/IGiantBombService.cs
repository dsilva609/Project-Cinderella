using BusinessLogic.Models;
using BusinessLogic.Models.GiantBombModels;

namespace BusinessLogic.Services.Interfaces
{
	public interface IGiantBombService
	{
		GiantBombResult Search(string query);

		Game SearchByID(int id);
	}
}