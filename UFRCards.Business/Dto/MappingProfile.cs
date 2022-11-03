using AutoMapper;
using UFRCards.Data.Entities;

namespace UFRCards.Business.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GameSession, GameSessionDto>()
            .ReverseMap();
    }
}