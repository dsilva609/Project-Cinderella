using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Service;
using Microsoft.AspNetCore.Identity.Service.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectCinderella.UI.Models;

namespace ProjectCinderella.UI.Data
{
	public class MyIdentityDbContext :IdentityDbContext<ApplicationUser>
		{
			public static string ConnectionString { get; set; }
		public MyIdentityDbContext(DbContextOptions<IdentityDbContext> options): base(options)
		{
			
		}

			public MyIdentityDbContext():base()
			{
				
			}
			protected override void OnConfiguring(DbContextOptionsBuilder builder)
			{
				builder.UseSqlServer(ConnectionString);
				//builder.UseSqlServer("Server=(local);Database=ProjectCinderellaCore;Trusted_Connection=True;MultipleActiveResultSets=true");
				base.
					OnConfiguring(builder);
			}
	}
}
