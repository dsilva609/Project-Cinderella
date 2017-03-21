using AutoMapper;
using BusinessLogic.Models;
using UI.MappingProfiles;
using UI.Models;

namespace UI
{
	public static class MappingProfile
	{
		public static void InitializeAutoMapper()
		{
			Mapper.Initialize(x =>
			{
				x.CreateMap<Album, AlbumViewModel>().ConvertUsing<AlbumToViewModelProfile>();
				x.CreateMap<AlbumViewModel, Album>().ConvertUsing<ViewModelToAlbumProfile>();

				x.CreateMap<Book, BookViewModel>().ConvertUsing<BookToViewModelProfile>();
				x.CreateMap<BookViewModel, Book>().ConvertUsing<ViewModelToBookProfile>();

				x.CreateMap<Game, GameViewModel>().ConvertUsing<GameToViewModelProfile>();
				x.CreateMap<GameViewModel, Game>().ConvertUsing<ViewModelToGameProfile>();

				x.CreateMap<Movie, MovieViewModel>().ConvertUsing<MovieToViewModelProfile>();
				x.CreateMap<MovieViewModel, Movie>().ConvertUsing<ViewModelToMovieProfile>();
			});
		}
	}
}