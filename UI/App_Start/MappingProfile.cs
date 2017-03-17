using AutoMapper;
using UI.MappingProfiles;

namespace UI
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AlbumViewModelProfile());
                //cfg.CreateMap<Question, QuestionModel>();
                //cfg.CreateMap<QuestionModel, Question>();
                /*etc...*/
            });

            return config;
        }
    }
}