using Google.Apis.Books.v1.Data;

namespace BusinessLogic.Services.Interfaces
{
	public interface IGoogleBookService
	{
		Volumes Search(string author, string title);

		Volume SearchISBN(string isbn);
	}
}