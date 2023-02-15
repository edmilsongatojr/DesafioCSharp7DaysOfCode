using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DesafioCSharp7DaysOfCode.Models
{
    public class Mascote
    {
        public int Id { get; set; }
        public HabilidadesPokemon[] Abilities { get; set; }
        public int Height { get; set; }
        public string Nome
        {
            get
            {
                if (String.IsNullOrEmpty(Nome))
                {
                    Nome = $"Mascotão Sem Nome Silva";
                }
                return Nome;
            }
            set
            {
                Nome = value;
            }
        }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Especie { get; set; }
        public List<string> Alimentacao { get; set; }
        public int Idade { get; private set; }
        public int StatusSaude
        {
            get { return StatusSaude; }

            set
            {
                if (StatusSaude > 100) value = 100;
                else if (StatusSaude < 0) value = 0;
                else StatusSaude = value;
            }
        }
        public int StatusFome
        {
            get { return StatusFome; }

            set
            {
                if (StatusFome > 100) value = 100;
                else if (StatusFome < 0) value = 0;
                else StatusFome = value;
            }
        }
        public int StatusHumor
        {
            get { return StatusHumor; }

            set
            {
                if (StatusHumor > 100) value = 100;
                else if (StatusHumor < 0) value = 0;
                else StatusHumor = value;
            }
        }
        public int StatusEnergia
        {
            get { return StatusEnergia; }

            set
            {
                if (StatusEnergia > 100) value = 100;
                else if (StatusEnergia < 0) value = 0;
                else StatusEnergia = value;
            }
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
