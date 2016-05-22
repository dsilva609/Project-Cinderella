using BusinessLogic.DAL;
using BusinessLogic.Models;
using System;
using System.Data.Entity;

namespace UI.Common
{
	//TODO: is this needed?
	public class ProjectCinderellaContextWrapper : IDisposable
	{
		public ProjectCinderellaContext Database { private get; set; }

		public void Dispose()
		{
			Database.Dispose();
		}

		public int SaveChanges()
		{
			return Database.SaveChanges();
		}

		public IDbSet<Album> Records() => Database.Albums;

		public IDbSet<Book> Books() => Database.Books;

		public IDbSet<Game> Games() => Database.Games;
	}
}