using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ProjectCinderella.Data.DAL
{
	public class ProjectCinderellaContextFactory : IDbContextFactory<ProjectCinderellaContext>
	{
		public ProjectCinderellaContext Create(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ProjectCinderellaContext>();
			optionsBuilder.UseSqlServer("Server=(local);Database=ProjectCinderellaCore;Trusted_Connection=True;MultipleActiveResultSets=true");//ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			return new ProjectCinderellaContext(optionsBuilder.Options);
		}
	}
}
