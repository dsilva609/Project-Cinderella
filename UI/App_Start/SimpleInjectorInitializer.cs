using BusinessLogic.DAL;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Google.Apis.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using UI;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace UI
{
	public static class SimpleInjectorInitializer
	{
		public static void Initialize()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			InitializeContainer(container);
			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}

		private static void InitializeContainer(Container c)
		{
			// For instance:
			// c.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
			c.Register<IUnitOfWork, UnitOfWork<ProjectCinderellaContext>>(Lifestyle.Singleton);
			c.Register<IAlbumService>(() => new AlbumService(c.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
			c.Register<IBookService>(() => new BookService(c.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
			c.Register<IMovieService>(() => new MovieService(c.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
			c.Register<IGameService>(() => new GameService(c.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
			c.Register<IPopService>(() => new PopService(c.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
			c.Register<IWishService>(() => new WishService(c.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
			c.Register<IDiscogsService, DiscogsService>();
			c.Register<IClientService>(() => new Google.Apis.Books.v1.BooksService(), Lifestyle.Scoped);
			c.Register<IGoogleBookService>(() => new GoogleBookService(c.GetInstance<IClientService>()), Lifestyle.Scoped);
			c.Register<ITMDBService, TMDBService>(Lifestyle.Scoped);
			c.Register<IBGGService, BGGService>(Lifestyle.Scoped);
			c.Register<IComicVineService, ComicVineService>(Lifestyle.Scoped);
			c.Register<IGiantBombService, GiantBombService>(Lifestyle.Scoped);
			c.Register<IStatisticService>(() => new StatisticService(c.GetInstance<IAlbumService>(), c.GetInstance<IBookService>(), c.GetInstance<IGameService>(), c.GetInstance<IMovieService>(), c.GetInstance<IWishService>()), Lifestyle.Scoped);
		}
	}
}