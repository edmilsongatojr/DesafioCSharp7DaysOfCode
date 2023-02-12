using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode.Models
{
    public class Mascote 
    { 
        public string Nome { get; set; }
        public string Especie { get; set; }
        public List<DadosPokemon> DadosMascote { get; set; }

        public Mascote(string nome,string especie)
        {
            Nome = nome;
            
            CarregaListaPokemons();
            CarregaEspecieMascote(especie);
           
        }

        private void CarregaEspecieMascote(string especie)
        {
            var especieEscolhida = from m in DadosMascote
                    where m.Name == especie
                    select m;

            Especie = especie;
            DadosMascote = especieEscolhida.ToList();
        }

        private void CarregaListaPokemons()
        {
            
            List<DadosPokemon> listDadosMascote = PokemonController.CarregaDadosPokemon();
            DadosMascote = listDadosMascote;
            
        }
    }
}
