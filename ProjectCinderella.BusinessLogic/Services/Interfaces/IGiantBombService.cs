using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.GiantBombModels;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
	public interface IGiantBombService
	{
		GiantBombResult Search(string query);

		Game SearchByID(int id);
	}
}