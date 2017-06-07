using System;
using Microsoft.AspNetCore.Authentication.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.Identity.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Web;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.Options;
using ProjectCinderella.Data.DAL;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.Interfaces;
using ProjectCinderella.BusinessLogic.Services;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using ProjectCinderella.BusinessLogic.Services.Statistics;

namespace ProjectCinderellaCore
{
    public class Startup
    {
	    private Container _container;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
			_container = new Container();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServiceAuthentication();
	        ProjectCinderellaContext.ConnectionString = Configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<ProjectCinderellaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
	        
			services.AddSingleton<IConfiguration>(Configuration);
	        services.AddOptions();
	        services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
	        services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(_container));
			services.UseSimpleInjectorAspNetRequestScoping(_container);
	        //services.Configure<ServiceSettings>(Configuration.GetSection("ServiceSettings"));
	        
			services.AddMvc();
        }
	    
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider svp)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseDevelopmentCertificateErrorPage(Configuration);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
			InitializeContainer(app);
			app.UseStaticFiles();

            app.UseRewriter(new RewriteOptions().AddIISUrlRewrite(env.ContentRootFileProvider, "urlRewrite.config"));

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
	    private void InitializeContainer(IApplicationBuilder app)
	    {
		    _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

		    // Add application presentation components:
		    _container.RegisterMvcControllers(app);
		    _container.RegisterMvcViewComponents(app);

			// Add application services. For instance:
		    _container.Register<IHttpContextAccessor, HttpContextAccessor>(Lifestyle.Scoped);
			//		    _container.Register<IUnitOfWork, UnitOfWork<ProjectCinderellaContext>>(Lifestyle.Singleton);
		    _container.RegisterSingleton<IUnitOfWork>(() => new UnitOfWork<ProjectCinderellaContext>());
			_container.Register<IAlbumService>(() => new AlbumService(_container.GetInstance<IUnitOfWork>(), _container.GetInstance<IUserContext>()), Lifestyle.Scoped);
		    _container.Register<IBookService>(() => new BookService(_container.GetInstance<IUnitOfWork>(), _container.GetInstance<IUserContext>()), Lifestyle.Scoped);
		    _container.Register<IMovieService>(() => new MovieService(_container.GetInstance<IUnitOfWork>(), _container.GetInstance<IUserContext>()), Lifestyle.Scoped);
		    _container.Register<IGameService>(() => new GameService(_container.GetInstance<IUnitOfWork>(), _container.GetInstance<IUserContext>()), Lifestyle.Scoped);
		    _container.Register<IPopService>(() => new PopService(_container.GetInstance<IUnitOfWork>(), _container.GetInstance<IUserContext>()), Lifestyle.Scoped);
		    _container.Register<IWishService>(() => new WishService(_container.GetInstance<IUnitOfWork>(), _container.GetInstance<IUserContext>()), Lifestyle.Scoped);
		    _container.Register<IDiscogsService, DiscogsService>(Lifestyle.Scoped);
		    _container.Register<IClientService>(() => new Google.Apis.Books.v1.BooksService(), Lifestyle.Scoped);
		    _container.Register<IGoogleBookService>(() => new GoogleBookService(_container.GetInstance<IClientService>()), Lifestyle.Scoped);
		    _container.Register<ITMDBService, TMDBService>(Lifestyle.Scoped);
		    _container.Register<IBGGService, BGGService>(Lifestyle.Scoped);
		    _container.Register<IComicVineService, ComicVineService>(Lifestyle.Scoped);
		    _container.Register<IGiantBombService, GiantBombService>(Lifestyle.Scoped);
		    _container.Register<IStatisticService>(() => new StatisticService(_container.GetInstance<IAlbumService>(), _container.GetInstance<IBookService>(), _container.GetInstance<IGameService>(), _container.GetInstance<IMovieService>(), _container.GetInstance<IPopService>(), _container.GetInstance<IWishService>()), Lifestyle.Scoped);
		    _container.Register<IAlbumStatisticService, AlbumStatisticService>(Lifestyle.Scoped);
		    _container.Register<IBookStatisticService, BookStatisticService>(Lifestyle.Scoped);
		    _container.Register<IMovieStatisticService, MovieStatisticService>(Lifestyle.Scoped);
		    _container.Register<IGameStatisticService, GameStatisticService>(Lifestyle.Scoped);
		    _container.Register<IPopStatisticService, PopStatisticService>(Lifestyle.Scoped);
		    _container.Register<IUserContext, UserContext>(Lifestyle.Scoped);
		    //_container.Register<IOptions<ServiceSettings>>(()=> GetServiceSettings());
			
			// Cross-wire ASP.NET services (if any). For instance:
			_container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());
			//--TODO:change how this is injected
			_container.RegisterSingleton<ServiceSettings>(()=> Configuration.GetSection("ServiceSettings").Get<ServiceSettings>());
			//_container.RegisterSingleton<IOptions<ServiceSettings>>(()=> app.ApplicationServices.GetRequiredService<IOptions<ServiceSettings>>());
		    // The following registers a Func<T> delegate that can be injected as singleton,
		    // and on invocation resolves a MVC IViewBufferScope service for that request.
		    _container.RegisterSingleton<Func<IViewBufferScope>>(
			    () => app.GetRequestService<IViewBufferScope>());

		    // NOTE: Do prevent cross-wired instances as much as possible.
		    // See: https://simpleinjector.org/blog/2016/07/
	    }
		//private IOptions<ServiceSettings> GetServiceSettings() => Configuration.GetSection("ServiceSettings").Get<ServiceSettings>();
	}
}