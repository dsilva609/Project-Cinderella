using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
	public enum GameTypeEnum
	{
		[Display(Name = "Full Game")]
		FullGame,

		DLC,
		Expansion
	}
}