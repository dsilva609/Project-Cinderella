using System.Data.Entity;

namespace BusinessLogic.DAL
{
	public class ProjectCinderellaInitializer : DropCreateDatabaseIfModelChanges<ProjectCinderellaContext>
	{
		protected override void Seed(ProjectCinderellaContext context)
		{
		}
	}
}