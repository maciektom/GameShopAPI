using AutoMapper;
using InternetGameShopAPI.Domain.GameAggregate;
using InternetGameShopAPI.Domain.UserAggregate;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Game, UserGame>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Game, opt => opt.Ignore());
    }
}