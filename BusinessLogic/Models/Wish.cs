using BusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class Wish
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string UserID { get; set; }

        public string ApiID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }

        [Required]
        public ItemType ItemType { get; set; }

        public string Notes { get; set; }

        public string Category { get; set; }
    }
}