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
            Mapper.Initialize(x => { x.CreateMap<Album, ItemViewModel>().ConvertUsing<AlbumViewModelProfile>(); });
        }
    }
}