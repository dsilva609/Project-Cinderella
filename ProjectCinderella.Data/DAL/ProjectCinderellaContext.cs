using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.DiscogsModels;

namespace ProjectCinderella.Data.DAL
{
	public class ProjectCinderellaContext : DbContext
	{
		public static string ConnectionString { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<Tracklist> Tracks { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<FunkoModel> Pops { get; set; }
		public DbSet<Wish> Wishes { get; set; }

		public ProjectCinderellaContext(DbContextOptions<ProjectCinderellaContext> options): base(options)
		{
		}

		public ProjectCinderellaContext(): base()
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
		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			builder.UseSqlServer(ConnectionString);
			//builder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=ProjectCinderella.Web;Trusted_Connection=True;MultipleActiveResultSets=true");
			base.OnConfiguring(builder);
		}
	}
}