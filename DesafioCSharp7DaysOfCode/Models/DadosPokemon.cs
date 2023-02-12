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
        public List<string> Alimentacao { get; set; }
        public int Idade { get; private set; }
        public int StatusSaude { get; set; }
        public DadosPokemon()
        {
            ObterSaude();
            ObterAlimentação();
        }

        public List<string> ObterAlimentação()
        {
            List<string> alimentacao = GerarAlimentacao();
            Alimentacao = alimentacao; ;
            return Alimentacao.ToList();
        }

        private static List<string> GerarAlimentacao()
        {
            List<string> alimentacao = new List<string>();
            EnumAlimentos alimento = EnumUtil.GetRandomValue<EnumAlimentos>();
            int totalEnum = EnumUtil.GetTotal<EnumAlimentos>();
            Random quantidadeAleatoria = new Random();
            int quantidadeAlimentos = quantidadeAleatoria.Next(3, 3);
            for (int i = 0; i < quantidadeAlimentos; i++)
            {
                alimento += 1;
                if ((int)alimento > totalEnum)
                {
                    alimento = (EnumAlimentos)(Convert.ToInt32(alimento) / 3);
                }
                alimentacao.Add(alimento.ToString());
            }

            return alimentacao;
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