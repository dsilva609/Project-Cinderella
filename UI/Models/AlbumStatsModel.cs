using System;
using System.Collections.Generic;

namespace UI.Models
{
	public class AlbumStatsModel
	{
		public AlbumTypesModel Types { get; set; }
		public AlbumFormatModel Formats { get; set; }
		public AlbumSpeedModel Speeds { get; set; }

		public List<Tuple<string, int>> TopArtists { get; set; }
		public List<Tuple<string, int>> TopGenres { get; set; }
		public List<Tuple<string, int>> TopRecordLabels { get; set; }
		public List<Tuple<string, int>> TopCountriesOfOrigin { get; set; }
		public List<Tuple<string, int>> TopPurchaseCountries { get; set; }
		public List<Tuple<string, int>> MostCompleted { get; set; }
		public List<Tuple<string, int>> TopLocationsPurchased { get; set; }
		public List<Tuple<int, int>> TopReleaseYears { get; set; }
	}

	public class AlbumFormatModel : ChartData
	{
		public int Num12Inch { get; set; }
		public int Num10Inch { get; set; }
		public int Num7Inch { get; set; }
	}

	public class AlbumSpeedModel : ChartData
	{
		public int Num33RPM { get; set; }
		public int Num45RPM { get; set; }
		public int Num78RPM { get; set; }
	}

	public class AlbumTypesModel : ChartData
	{
		public int NumVinyl { get; set; }
		public int NumCD { get; set; }
	}
}