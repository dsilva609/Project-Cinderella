using ProjectCinderella.Model.BGGModels;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
	public interface IBGGService
	{
		BGGGame Search(string query);

		Game SearchByID(int id);
	}
}