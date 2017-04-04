namespace UI.Models
{
	public class StatsViewModel
	{
		public string Title { get; set; }
		public MediaTypes MediaTypes { get; set; }
		public ItemTypes ItemTypes { get; set; }
		public Condition Condition { get; set; }
		public CompletionStatus CompletionStatus { get; set; }

		public int CollectionCount { get; set; }
		public int TimesCompleted { get; set; }
		public int NumCheckedOut { get; set; }
	}

	public class MediaTypes : ChartData
	{
		public int NumPhysical { get; set; }
		public int NumDigital { get; set; }
	}

	public class ItemTypes : ChartData
	{
		public int NumAlbums { get; set; }
		public int NumBooks { get; set; }
		public int NumMoviesAndShows { get; set; }
		public int NumGames { get; set; }
		public int NumPops { get; set; }
		public int NumWishes { get; set; }
		public int NumShowcased { get; set; }
	}

	public class Condition : ChartData
	{
		public int NumNew { get; set; }
		public int NumUsed { get; set; }
	}

	public class CompletionStatus : ChartData
	{
		public int NumNotStarted { get; set; }
		public int NumInProgress { get; set; }
		public int NumCompleted { get; set; }
	}

	public class ChartData
	{
		public string Title { get; set; }
		public string ID { get; set; }
	}
}