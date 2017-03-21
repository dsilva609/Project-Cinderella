using System;
using AutoMapper;
using BusinessLogic.Models;
using UI.Models;

namespace UI.MappingProfiles
{
	public class MovieToViewModelProfile : ITypeConverter<Movie, MovieViewModel>
	{
		public MovieViewModel Convert(Movie source, MovieViewModel destination, ResolutionContext context)
		{
			throw new NotImplementedException();
		}
	}

	public class ViewModelToMovieProfile : ITypeConverter<MovieViewModel, Movie>
	{
		public Movie Convert(MovieViewModel source, Movie destination, ResolutionContext context)
		{
			throw new NotImplementedException();
		}
	}
}