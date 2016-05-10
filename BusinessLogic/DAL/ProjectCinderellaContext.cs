using BusinessLogic.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BusinessLogic.DAL
{
	public class ProjectCinderellaContext : DbContext
	{
		public DbSet<RecordModel> Records { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Movie> Movies { get; set; }

		public ProjectCinderellaContext()
			: base("ProjectCinderella")
		{
			this.Configuration.LazyLoadingEnabled = false;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}