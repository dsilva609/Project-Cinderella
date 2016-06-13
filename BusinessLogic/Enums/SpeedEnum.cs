using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
	public enum SpeedEnum
	{
		[Display(Name = "33 1/3 RPM")]
		RPM33,

		[Display(Name = "45 RPM")]
		RPM45,

		[Display(Name = "78 RPM")]
		RPM78
	}
}