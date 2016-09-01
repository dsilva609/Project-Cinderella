using BusinessLogic.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class Book : BaseItem
    {
        [Required]
        public string Author { get; set; }

        [Required]
        public BookTypeEnum Type { get; set; }

        public bool Hardcover { get; set; }

        [Display(Name = "First Edition?")]
        public bool IsFirstEdition { get; set; }

        [Required]
        public string Publisher { get; set; }

        [DisplayName("Page Count")]
        public int PageCount { get; set; }

        [DisplayName("ISBN 10")]
        public string ISBN10 { get; set; }

        [DisplayName("ISBN 13")]
        public string ISBN13 { get; set; }

        [Display(Name = "Reissue?")]
        public bool IsReissue { get; set; }

        public string GoogleBookID { get; set; }
    }
}