using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public Mascote()
        {
        }
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
        public void SalvarDadosMascote()
        {
            string caminhoArquivo = "DadosMascote.json";
            
            string json = JsonConvert.SerializeObject(this);
            using (StreamWriter fluxoJson = new StreamWriter(caminhoArquivo))
            {
                    fluxoJson.WriteLine(json);
            }
        }
        public Mascote CarregarDadosMascote()
        {
            string caminhoArquivo = "DadosMascote.json";

            Mascote mascote = this;

            using (StreamReader fluxoJson = new StreamReader(caminhoArquivo))
            {
                mascote = JsonConvert.DeserializeObject<Mascote>(fluxoJson.ReadLine()); 
            }
            return mascote;
        }
    }
}
