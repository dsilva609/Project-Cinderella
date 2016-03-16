using AutoMapper;
using BusinessLogic.Models;
using UI.Models;

namespace UI.App_Start
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