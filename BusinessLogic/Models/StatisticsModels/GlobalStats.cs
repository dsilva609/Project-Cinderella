namespace BusinessLogic.Models.StatisticsModels
{
    public class GlobalStats : CollectionStatistic
    {
        public int NumAlbums { get; set; }
        public int NumBooks { get; set; }
        public int NumMoviesAndShows { get; set; }
        public int NumGames { get; set; }
    }
}