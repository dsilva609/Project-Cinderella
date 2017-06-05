using System.ComponentModel;

namespace ProjectCinderella.Model.DiscogsModels
{
	public class DiscogsResult
	{
		public string[] Style { get; set; }
		public string Thumb { get; set; }
		public string Title { get; set; }
		public string Country { get; set; }
		public string[] Format { get; set; }

		[DisplayName("Format")]
		public string FormatString { get; set; }

		public string Uri { get; set; }
		public string[] Label { get; set; }

		[DisplayName("Label")]
		public string LabelString { get; set; }

		public string Catno { get; set; }
		public int Year { get; set; }
		public string[] Genre { get; set; }
		public string GenreString { get; set; }
		public string ResourceUrl { get; set; }
		public string Type { get; set; }
		public int ID { get; set; }
		public string[] Barcode { get; set; }
	}
}