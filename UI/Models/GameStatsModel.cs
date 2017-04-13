using System.Collections.Generic;

namespace UI.Models
{
    public class GameStatsModel
    {
        public List<string> TopDevelopers { get; set; }

        public List<string> TopPublishers { get; set; }
        public GameTypesModel Types { get; set; }
        public GameRatingModel Ratings { get; set; }

        public GamePlatformsModel Platforms { get; set; }

        public List<string> TopCountriesOfOrigin { get; set; }

        public List<string> TopPurchaseCountries { get; set; }

        public List<string> MostCompleted { get; set; }

        public List<string> TopLocationsPurchased { get; set; }

        public List<int> TopReleaseYears { get; set; }
    }

    public class GameTypesModel : ChartData
    {
        public int NumFullGame { get; set; }

        public int NumDLC { get; set; }

        public int NumExpansion { get; set; }
    }

    public class GameRatingModel : ChartData
    {
        public int NumRatedEC { get; set; }

        public int NumRatedE { get; set; }

        public int NumRatedE10 { get; set; }

        public int NumRatedT { get; set; }

        public int NumRatedM { get; set; }

        public int NumRatedA { get; set; }
    }

    public class GamePlatformsModel : ChartData
    {
        public CurrentGeneration CurrentGeneration { get; set; }
        public OtherPlatforms Other { get; set; }

        public Sony Sony { get; set; }
        public Microsoft Microsoft { get; set; }
        public Nintendo Nintendo { get; set; }
        public Handhelds Handhelds { get; set; }
    }

    public class CurrentGeneration : ChartData
    {
        public int NumPlayStation4 { get; set; }
        public int NumXboxOne { get; set; }
        public int NumNintendoSwitch { get; set; }
    }

    public class OtherPlatforms : ChartData
    {
        public int NumBoardGame { get; set; }

        public int NumPC { get; set; }
    }

    public class Sony : ChartData
    {
        public int NumPlayStation { get; set; }

        public int NumPlayStation2 { get; set; }

        public int NumPlayStation3 { get; set; }

        public int NumPlayStation4 { get; set; }
        public int NumPSP { get; set; }

        public int NumPSVita { get; set; }
    }

    public class Microsoft : ChartData
    {
        public int NumXbox { get; set; }

        public int NumXbox360 { get; set; }

        public int NumXboxOne { get; set; }
    }

    public class Nintendo : ChartData
    {
        public int NumNintendo64 { get; set; }

        public int NumGameCube { get; set; }
        public int NumGameBoy { get; set; }

        public int NumGameBoyAdvance { get; set; }

        public int NumNintendoDS { get; set; }

        public int NumNintendo3DS { get; set; }
        public int NumWii { get; set; }

        public int NumWiiU { get; set; }

        public int NumNintendoSwitch { get; set; }
    }

    public class Handhelds : ChartData
    {
        public int NumGameBoy { get; set; }

        public int NumGameBoyAdvance { get; set; }

        public int NumNintendoDS { get; set; }

        public int NumNintendo3DS { get; set; }

        public int NumPSP { get; set; }

        public int NumPSVita { get; set; }
    }
}