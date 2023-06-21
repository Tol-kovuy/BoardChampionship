using AutoMapper;
using BoardChampionship.DAL.Entities;
using BoardChampionship.Models;

namespace BoardChampionship;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Player, PlayerViewModel>().ReverseMap();
        CreateMap<Team, TeamViewModel>().ReverseMap();
        CreateMap<Game, GameViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.GamesNumber, opt => opt.MapFrom(src => src.Raund))
            .ForMember(dest => dest.ScoredGoals, opt => opt.MapFrom(src => src.ScoredGoals))
            .ForMember(dest => dest.ConcededGoals, opt => opt.MapFrom(src => src.ConcededGoals))
            .ForMember(dest => dest.Team, opt => opt.Ignore());
        CreateMap<GameViewModel, Game>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Raund, opt => opt.MapFrom(src => src.GamesNumber))
            .ForMember(dest => dest.ScoredGoals, opt => opt.MapFrom(src => src.ScoredGoals))
            .ForMember(dest => dest.ConcededGoals, opt => opt.MapFrom(src => src.ConcededGoals))
            .ForMember(dest => dest.Team, opt => opt.Ignore());
        CreateMap<Winner, WinnerViewModel>().ReverseMap();
    }
}
