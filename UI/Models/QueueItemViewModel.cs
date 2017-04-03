using BusinessLogic.Enums;

namespace UI.Models
{
    public class QueueItemViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int QueueRank { get; set; }
        public ItemType ItemType { get; set; }
    }
}