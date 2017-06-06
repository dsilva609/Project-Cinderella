using Microsoft.EntityFrameworkCore;
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

		public ProjectCinderellaContext(DbContextOptions<ProjectCinderellaContext> options)
			: base(options)
		{
			//Configuration.LazyLoadingEnabled = false;
		}

		public ProjectCinderellaContext()
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Album>().ToTable("Album");
			modelBuilder.Entity<Tracklist>().ToTable("Tracklist");
			modelBuilder.Entity<Book>().ToTable("Book");
			modelBuilder.Entity<Movie>().ToTable("Movie");
			modelBuilder.Entity<Game>().ToTable("Game");
			modelBuilder.Entity<FunkoModel>().ToTable("Pop");
			modelBuilder.Entity<Wish>().ToTable("Wish");
			}
	}
}