using System.Collections.Generic;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.DiscogsModels;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
	public interface IDiscogsService
	{
		List<DiscogsResult> Search(string artist, string album);

		Album GetRelease(int releaseID);
	}
}