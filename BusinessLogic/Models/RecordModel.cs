﻿using BusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class RecordModel
    {
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        [DisplayName("Album Name")]
        public string AlbumName { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public string Artist { get; set; }

        public string Genre { get; set; }

        [DisplayName("Album Year")]
        public int AlbumYear { get; set; }

        [Key]
        [Column(Order = 3)]
        [Required]
        [DisplayName("Media Type")]
        public MediaTypeEnum MediaType { get; set; }

        [Required]
        [DisplayName("Is Physical")]
        public bool IsPhysical { get; set; }

        [Required]
        [DisplayName("Is New")]
        public bool IsNew { get; set; }

        [DisplayName("Location Purchased")]
        public string LocationPurchased { get; set; }

        [DisplayName("Date Purchased")]
        public DateTime DatePurchased { get; set; }
    }
}