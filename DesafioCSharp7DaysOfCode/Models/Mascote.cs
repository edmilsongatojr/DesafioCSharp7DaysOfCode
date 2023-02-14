using DesafioCSharp7DaysOfCode.Controllers;
using DesafioCSharp7DaysOfCode.Enums;
using DesafioCSharp7DaysOfCode.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesafioCSharp7DaysOfCode.Models
{
    public class Mascote
    {
        public List<DadosPokemon> DadosMascote { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public List<string> Alimentacao { get; set; }
        public int Idade { get; private set; }
        public int StatusSaude { get; set; }
        public int StatusFome { get; set; }
        public int StatusHumor { get; set; }
        public int StatusEnergia { get; set; }

        public Mascote()
        {
            ObterSaude();
            ObterAlimentação();
        }
        public Mascote(string nome, string especie)
        {
            Nome = nome;

            CarregaListaPokemons();
            CarregaEspecieMascote(especie);
            InicilizacaoPadraoMascote();
        }

        private void InicilizacaoPadraoMascote()
        {
            StatusHumor = 100;
            StatusEnergia = 100;
            StatusFome = 0;
            ObterSaude();
            ObterAlimentação();
        }

        public List<string> ObterAlimentação()
        {
            List<string> alimentacao = MascoteController.GerarAlimentacao();
            Alimentacao = alimentacao; ;
            return Alimentacao.ToList();
        }
        public int ObterSaude()
        {
            Random random = new Random();
            string statusSaude = random.Next().ToString();
            statusSaude = statusSaude.Substring(0, 2);
            return StatusSaude = Convert.ToInt32(statusSaude);
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

            List<DadosPokemon> listDadosMascote = PokemonService.CarregaDadosPokemon();
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
