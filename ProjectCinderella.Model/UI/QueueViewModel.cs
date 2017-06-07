using System.Collections.Generic;

namespace ProjectCinderella.Model.UI
{
	public class QueueViewModel
	{
		public List<QueueItemViewModel> Albums { get; set; }
		public List<QueueItemViewModel> Books { get; set; }
		public List<QueueItemViewModel> Games { get; set; }
		public List<QueueItemViewModel> Movies { get; set; }
	}
}