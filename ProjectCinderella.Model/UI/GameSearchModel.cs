using ProjectCinderella.Model.BGGModels;
using ProjectCinderella.Model.GiantBombModels;

namespace ProjectCinderella.Model.UI
{
	public class GameSearchModel
	{
		public string Title { get; set; }

		public GiantBombResult GiantBombResult { get; set; }

		public BGGGame BGGResult { get; set; }
	}
}