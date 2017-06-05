using BusinessLogic.Migrations;
using Microsoft.EntityFrameworkCore;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.DiscogsModels;

namespace ProjectCinderella.Data.DAL
{
	public class ProjectCinderellaContext : DbContext
	{
		public DbSet<Album> Album { get; set; }
		public DbSet<Tracklist> Track { get; set; }
		public DbSet<Book> Book { get; set; }
		public DbSet<Movie> Movie { get; set; }
		public DbSet<Game> Game { get; set; }
		public DbSet<FunkoModel> Pop { get; set; }
		public DbSet<Wish> Wishe { get; set; }

		public ProjectCinderellaContext()
			: base("ProjectCinderella")
		{
			//Configuration.LazyLoadingEnabled = false;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}