using BusinessLogic.DAL;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using UI;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace UI
{
	public static class SimpleInjectorInitializer
	{
		/// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
		public static void Initialize()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			InitializeContainer(container);
			//TODO: add this back later
			//container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}

		private static void InitializeContainer(Container container)
		{
			// For instance:
			// container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
			container.Register<IUnitOfWork, UnitOfWork<ProjectCinderellaContext>>(Lifestyle.Singleton);
			container.Register<IAlbumService>(() => new AlbumService(container.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
			container.Register<IBookService>(() => new BookService(container.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
			container.Register<IMovieService>(() => new MovieService(container.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
			container.Register<IGameService>(() => new GameService(container.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
		}
	}
}