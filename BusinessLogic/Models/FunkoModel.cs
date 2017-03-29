using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class FunkoModel : BaseItem
	{
		[Required]
		public string Series { get; set; }

		[Required]
		public string PopLine { get; set; }

		[Required]
		public int Number { get; set; }
	}
}