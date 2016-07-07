using BusinessLogic.Services.Interfaces;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;

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
			var query = string.Empty;
			if (!string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(title))
				query = $"inauthor:{author}+intitle:{title}";
			else if (!string.IsNullOrWhiteSpace(author) && string.IsNullOrWhiteSpace(title))
				query = $"inauthor:{author}";
			else if (string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(title))
				query = $"intitle:{title}";

			var result = _service.List(query);

			return result.Execute();
		}

		public Volume SearchByID(string id)
		{
			var result = _service.Get(id).Execute();

			return result;
		}
	}
}