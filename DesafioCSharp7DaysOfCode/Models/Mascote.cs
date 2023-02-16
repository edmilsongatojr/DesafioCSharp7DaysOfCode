using DesafioCSharp7DaysOfCode.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DesafioCSharp7DaysOfCode.Models
{
    public class Mascote
    {
        private string nome;
        private int statusSaude;
        private int statusFome;
        private int statusHumor;
        private int statusEnergia;
        public int Id { get; set; }
        public HabilidadesPokemon[] Abilities { get; set; }
        public int Height { get; set; }
        public string Nome
        {
            get
            {
                if (String.IsNullOrEmpty(nome))
                {
                    nome = $"Mascotão Sem Nome Silva";
                }
                return nome;
            }
            set
            {
                nome = value;
            }
        }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Especie { get; set; }
        public List<string> Alimentacao { get; set; }
        public int Idade { get; private set; }
        public int StatusSaude
        {
            get { return statusSaude; }

            set
            {
                if (value > 100) statusSaude = 100;
                else if (value < 0) statusSaude = 0;
                else statusSaude = value;
            }
        }
        public int StatusFome
        {
            get { return statusFome; }

            set
            {
                if (value > 100) statusFome = 100;
                else if (value < 0) statusFome = 0;
                else statusFome = value;
            }
        }
        public int StatusHumor
        {
            get { return statusHumor; }

            set
            {
                if (value > 100) statusHumor = 100;
                else if (value < 0) statusHumor = 0;
                else statusHumor = value;
            }
        }
        public int StatusEnergia
        {
            get { return statusEnergia; }

            set
            {
                if (value > 100) statusEnergia = 100;
                else if (value < 0) statusEnergia = 0;
                else statusEnergia = value;
            }
        }


        public void SalvarDadosMascote()
        {
            try
            {
                string caminhoArquivo = "DadosMascote.json";
                string json = JsonConvert.SerializeObject(this);
                using (StreamWriter fluxoJson = new StreamWriter(caminhoArquivo))
                {
                    fluxoJson.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
        }
        public Mascote CarregarDadosMascote()
        {
            try
            {
                string caminhoArquivo = "DadosMascote.json";
                Mascote mascote = this;
                using (StreamReader fluxoJson = new StreamReader(caminhoArquivo))
                {
                    mascote = JsonConvert.DeserializeObject<Mascote>(fluxoJson.ReadLine());
                }
                return mascote;

            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
                return null;
            }
        }

        public bool ValidarDadosSalvos()
        {
            try
            {
                Mascote _mascote = CarregarDadosMascote();
                if (_mascote is null )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
