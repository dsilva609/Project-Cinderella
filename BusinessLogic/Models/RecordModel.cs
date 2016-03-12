using BusinessLogic.Enums;
using System;

namespace BusinessLogic.Models
{
    public class RecordModel
    {
        public int ID { get; set; }
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int AlbumYear { get; set; }
        public MediaTypeEnum MediaType { get; set; }
        public bool IsPhysical { get; set; }
        public bool IsNew { get; set; }
        public string LocationPurchased { get; set; }
        public DateTime DatePurchased { get; set; }
    }
}