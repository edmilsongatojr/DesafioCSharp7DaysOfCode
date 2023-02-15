using AutoMapper;
using DesafioCSharp7DaysOfCode.Models;

namespace DesafioCSharp7DaysOfCode.AutoMapperController
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DadosPokemon, Mascote>();
        }
    }
}
