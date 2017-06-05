using System.ComponentModel.DataAnnotations;

namespace ProjectCinderella.Model.Enums
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