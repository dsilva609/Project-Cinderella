using BusinessLogic.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
	public class GoogleBooksSearchModel
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Author { get; set; }

		public List<Book> Volumes { get; set; }
	}
}