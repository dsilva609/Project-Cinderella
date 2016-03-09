using BusinessLogic.DAL;
using System;
using System.Data.Entity;

namespace UI.Common
{
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
	}
}