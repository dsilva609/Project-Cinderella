using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinderella.Model.Common
{
	public class FunkoModel : BaseItem
	{
		[Required]
		public string Series { get; set; }

		[Required]
		[DisplayName("Pop Line")]
		public string PopLine { get; set; }

		[Required]
		public int Number { get; set; }
	}
}