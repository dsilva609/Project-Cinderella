using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BusinessLogic.Models;
using UI.Models;

namespace UI.MappingProfiles
{
	public class BookToViewModelProfile : ITypeConverter<Book, BookViewModel>
	{
		public BookViewModel Convert(Book source, BookViewModel destination, ResolutionContext context)
		{
			throw new NotImplementedException();
		}
	}

	public class ViewModelToBookProfile : ITypeConverter<BookViewModel, Book>
	{
		public Book Convert(BookViewModel source, Book destination, ResolutionContext context)
		{
			throw new NotImplementedException();
		}
	}
}