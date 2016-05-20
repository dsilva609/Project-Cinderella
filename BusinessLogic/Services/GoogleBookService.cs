using BusinessLogic.Services.Interfaces;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;

namespace BusinessLogic.Services
{
	public class GoogleBookService : IGoogleBookService
	{
		public Volumes Search(string author, string title)
		{
			Google.Apis.Books.v1.VolumesResource service = new VolumesResource(new BooksService());
			var result = service.List("civil+war+inauthor:Mark+Millar");
			return result.Execute();
		}
	}
}