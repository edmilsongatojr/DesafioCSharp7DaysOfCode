using AutoMapper;
using DesafioCSharp7DaysOfCode.Controllers;
using DesafioCSharp7DaysOfCode.Enums;
using DesafioCSharp7DaysOfCode.Services;
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
        public string Nome { get; set; }
        public int Weight { get; set; }
        public string Especie { get; set; }
        public List<string> Alimentacao { get; set; }
        public int Idade { get; private set; }
        public int StatusSaude { get; set; }
        public int StatusFome { get; set; }
        public int StatusHumor { get; set; }
        public int StatusEnergia { get; set; }

        public DadosPokemon()
        {
            
        }
        public DadosPokemon(string nome, string especie)
        {
            Nome = nome;
            Especie = especie;
            CarregaEspecieMascote(especie);
        }
        private void CarregaEspecieMascote(string especie)
        {
            var especieEscolhida = from m in PokemonService.CarregaDadosPokemon()
                                   where m.Name == especie.ToLower()
                                   select m;

            foreach (var dados in especieEscolhida)
            {
                this.Id = dados.Id;
                this.Name = dados.Name;
                this.Height = dados.Height;
                this.Weight = dados.Weight;
                this.Abilities = dados.Abilities;
            }
            InicilizacaoPadraoMascote();

        }
        
        public void InicilizacaoPadraoMascote()
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
    }
}