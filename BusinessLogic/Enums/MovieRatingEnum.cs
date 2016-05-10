using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
	public enum MovieRatingEnum
	{
		G,
		PG,

		[Display(Name = "PG-13")]
		PG13,

		R,
		NR
	}
}