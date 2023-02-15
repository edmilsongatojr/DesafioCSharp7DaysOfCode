using AutoMapper;
using DesafioCSharp7DaysOfCode.Models;

namespace DesafioCSharp7DaysOfCode.AutoMapperController
{
    public class AutoMapperUtil
    {
      
        public static void InicializaAutoMapper()
        {
             Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DadosPokemon, Mascote>();
            });
        }
    }
}
