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
    }
}
