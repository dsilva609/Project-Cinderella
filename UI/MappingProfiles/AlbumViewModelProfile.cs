using AutoMapper;
using BusinessLogic.Models;
using UI.Models;

namespace UI.MappingProfiles
{
    public class AlbumViewModelProfile : Profile
    {
        public AlbumViewModelProfile()
        {
            CreateMap<Album, ItemViewModel>();
        }
    }
}