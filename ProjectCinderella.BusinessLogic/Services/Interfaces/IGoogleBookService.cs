using System.Collections.Generic;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
	public interface IGoogleBookService
	{
		List<Book> Search(string author, string title);

		Book SearchByID(string id);
	}
}