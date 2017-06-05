using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.DiscogsModels;

namespace ProjectCinderella.Data.DAL
{
	public class ProjectCinderellaContext : DbContext
	{
		public DbSet<Album> Albums { get; set; }
		public DbSet<Tracklist> Tracks { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<FunkoModel> Pops { get; set; }
		public DbSet<Wish> Wishes { get; set; }

		public ProjectCinderellaContext()
			: base("ProjectCinderella")
		{
			Configuration.LazyLoadingEnabled = false;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}