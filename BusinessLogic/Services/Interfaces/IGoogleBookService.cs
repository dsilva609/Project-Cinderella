using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface IGoogleBookService
	{
		List<Book> Search(string author, string title);

		Book SearchByID(string id);
	}
}