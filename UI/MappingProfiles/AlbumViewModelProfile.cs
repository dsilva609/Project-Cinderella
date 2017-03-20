using AutoMapper;
using BusinessLogic.Models;
using UI.Models;

namespace UI.MappingProfiles
{
    public class AlbumViewModelProfile : ITypeConverter<Album, ItemViewModel>
    {
        public ItemViewModel Convert(Album source, ItemViewModel destination, ResolutionContext context)
        {
            destination = new ItemViewModel
            {
                InfoView = new ItemInfoViewModel
                {
                    Title = source.Title
                }
            };

            return destination;
        }
    }
}