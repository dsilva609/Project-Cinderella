using BusinessLogic.Models.DiscogsModels;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface IDiscogsService
	{
		List<DiscogsResult> Search(string artist, string album);
	}
}