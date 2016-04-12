using BusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class RecordModel
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string UserID { get; set; }

        //[Key]
        [Column(Order = 1)]
        [Required]
        [DisplayName("Album Name")]
        public string AlbumName { get; set; }

        //[Key]
        [Column(Order = 2)]
        [Required]
        public string Artist { get; set; }

        public string Genre { get; set; }

        [DisplayName("Album Year")]
        public int AlbumYear { get; set; }

        //[Key]
        [Column(Order = 3)]
        [Required]
        [DisplayName("Media Type")]
        public MediaTypeEnum MediaType { get; set; }

        [Required]
        [DisplayName("Physical?")]
        public bool IsPhysical { get; set; }

        [Required]
        [DisplayName("New?")]
        public bool IsNew { get; set; }

        [DisplayName("Location Purchased")]
        public string LocationPurchased { get; set; }

        [DisplayName("Date Purchased")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DatePurchased { get; set; } = DateTime.Now;
    }
}