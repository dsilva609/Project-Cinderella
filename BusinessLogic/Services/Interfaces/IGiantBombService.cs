using BusinessLogic.Models.GiantBombModels;

namespace BusinessLogic.Services.Interfaces
{
	public interface IGiantBombService
	{
		GiantBombResult Search(string query);

		GiantBombGame SearchByID(int id);
	}
}