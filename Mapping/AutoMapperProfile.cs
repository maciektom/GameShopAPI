using AutoMapper;
using InternetGameShopAPI.Domain;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Game, UserGames>()
            .ForMember(dest => dest.User_id, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Game_id, opt => opt.MapFrom(src => src.GameId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Game, opt => opt.Ignore());
    }
}