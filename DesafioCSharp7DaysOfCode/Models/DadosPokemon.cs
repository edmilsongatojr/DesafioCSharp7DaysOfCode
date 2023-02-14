using DesafioCSharp7DaysOfCode.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioCSharp7DaysOfCode.Models
{
    public class DadosPokemon
    {
        public int Id { get; set; }
        public HabilidadesPokemon[] Abilities { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        


        public DadosPokemon()
        {
            
        }
        
        
    }
}