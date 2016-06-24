using BusinessLogic.Services.Interfaces;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using System.Linq;

namespace BusinessLogic.Services
{
	public class GoogleBookService : IGoogleBookService
	{
		private readonly IClientService _googleClient;
		private readonly VolumesResource _service;

		public GoogleBookService(IClientService client)
		{
			_service = new VolumesResource(client);
		}

		public Volumes Search(string author, string title)
		{
			var result = _service.List($"inauthor:{author}+intitle:{title}");

			return result.Execute();
		}

		public Volume SearchISBN(string isbn)
		{
			var result = _service.List($"isbn:{isbn}").Execute().Items.FirstOrDefault();

			return result;
		}
	}
}