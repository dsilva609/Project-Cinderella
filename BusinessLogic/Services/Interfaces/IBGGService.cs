using BusinessLogic.Models.BGGModels;

namespace BusinessLogic.Services.Interfaces
{
	public interface IBGGService
	{
		BGGResult Search(string query);

		BGGGame SearchByID(int id);
	}
}