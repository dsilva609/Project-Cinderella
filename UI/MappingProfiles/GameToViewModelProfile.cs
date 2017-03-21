using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BusinessLogic.Models;
using UI.Models;

namespace UI.MappingProfiles
{
	public class GameToViewModelProfile : ITypeConverter<Game, GameViewModel>
	{
		public GameViewModel Convert(Game source, GameViewModel destination, ResolutionContext context)
		{
			throw new NotImplementedException();
		}
	}

	public class ViewModelToGameProfile : ITypeConverter<GameViewModel, Game>
	{
		public Game Convert(GameViewModel source, Game destination, ResolutionContext context)
		{
			throw new NotImplementedException();
		}
	}
}