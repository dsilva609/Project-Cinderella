using BusinessLogic.Models;
using BusinessLogic.Models.BGGModels;

namespace BusinessLogic.Services.Interfaces
{
	public interface IBGGService
	{
		BGGGame Search(string query);

		Game SearchByID(int id);
	}
}