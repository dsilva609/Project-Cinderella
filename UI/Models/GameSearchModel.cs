using BusinessLogic.Models.BGGModels;
using BusinessLogic.Models.GiantBombModels;

namespace UI.Models
{
	public class GameSearchModel
	{
		public string Title { get; set; }

		public GiantBombResult GiantBombResult { get; set; }

		public BGGGame BGGResult { get; set; }
	}
}