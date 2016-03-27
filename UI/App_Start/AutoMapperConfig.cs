using AutoMapper;
using BusinessLogic.Models;
using UI.Models;

namespace UI
{
	public static class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.CreateMap<RecordViewModel, RecordModel>();
			Mapper.CreateMap<RecordModel, RecordViewModel>();
		}
	}
}