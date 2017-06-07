using System.ComponentModel.DataAnnotations;
using PagedList;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.Model.UI
{
    public class MovieViewModel : BaseViewModel
    {
        public IPagedList<Movie> Movies { get; set; }
        public MovieInfoModel MovieInfo { get; set; }
        public MovieMediaInfoModel MediaInfo { get; set; }
        public PurchaseInfoViewModel PurchaseInfo { get; set; }
        public ItemStatusViewModel StatusInfo { get; set; }
    }

    public class MovieInfoModel : ItemInfoViewModel
    {
        [Required]
        public string Director { get; set; }

        public string Distributor { get; set; }
        public int TMDBID { get; set; }
    }

    public class MovieMediaInfoModel : MediaInfoViewModel
    {
        public MovieMediaTypeEnum Type { get; set; }

        public MovieRatingEnum Rating { get; set; }
    }
}