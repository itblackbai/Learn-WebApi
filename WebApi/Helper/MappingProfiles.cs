using AutoMapper;
using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
        }
    }
}
 