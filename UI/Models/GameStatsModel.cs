using System.Collections.Generic;

namespace UI.Models
{
    public class GameStatsModel
    {
        public List<string> TopDevelopers { get; set; }

        public List<string> TopPublishers { get; set; }

        public int NumFullGame { get; set; }

        public int NumDLC { get; set; }

        public int NumExpansion { get; set; }

        public int NumRatedEC { get; set; }

        public int NumRatedE { get; set; }

        public int NumRatedE10 { get; set; }

        public int NumRatedT { get; set; }

        public int NumRatedM { get; set; }

        public int NumRatedA { get; set; }

        public int NumBoardGame { get; set; }

        public int NumPC { get; set; }

        public int NumPlayStation { get; set; }

        public int NumPlayStation2 { get; set; }

        public int NumPlayStation3 { get; set; }

        public int NumPlayStation4 { get; set; }

        public int NumXbox { get; set; }

        public int NumXbox360 { get; set; }

        public int NumXboxOne { get; set; }

        public int NumNintendo64 { get; set; }

        public int NumGameCube { get; set; }

        public int NumWii { get; set; }

        public int NumWiiU { get; set; }

        public int NumNintendoSwitch { get; set; }

        public int NumGameBoy { get; set; }

        public int NumGameBoyAdvance { get; set; }

        public int NumNintendoDS { get; set; }

        public int NumNintendo3DS { get; set; }

        public int NumPSP { get; set; }

        public int NumPSVita { get; set; }

        public List<string> TopCountriesOfOrigin { get; set; }

        public List<string> TopPurchaseCountries { get; set; }

        public List<string> MostCompleted { get; set; }

        public List<string> TopLocationsPurchased { get; set; }

        public List<int> TopReleaseYears { get; set; }
    }
}