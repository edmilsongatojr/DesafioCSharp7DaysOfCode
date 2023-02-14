using DesafioCSharp7DaysOfCode.Connections;
using DesafioCSharp7DaysOfCode.Enums;
using DesafioCSharp7DaysOfCode.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DesafioCSharp7DaysOfCode.Controllers
{
    public class MascoteController
    {
        public Mascote Mascote { get; set; }
        public MascoteController()
        {

        }
        public MascoteController(Mascote mascote)
        {
            Mascote = mascote;
        }
        internal void BrincarMascote()
        {
            Mascote.StatusHumor += 10;
            Mascote.StatusSaude++;
            Mascote.StatusFome += 20;
            Mascote.StatusEnergia -= 15;

            Console.WriteLine($"|-> {Mascote.Nome} Diz: {Mascote.Nome}...{Mascote.Nome}...{Mascote.Nome} :)");
        }
        internal void AlimentarMascote()
        {
            
        }
        internal void NinarMascote()
        {
            if (Mascote.StatusEnergia.Equals(100))
            {
                Console.WriteLine($"| O {Mascote.Nome} não tem sono! Ele quer consquistar o mundoo :) GrrahhH");

            }
            else Mascote.StatusEnergia = 100;
        }
        internal void MedicarMascote()
        {
            Mascote.StatusHumor += 20;
            Mascote.StatusEnergia += (Mascote.StatusEnergia / 2);
            Mascote.StatusSaude = 100;
        }
        internal static List<string> GerarAlimentacao()
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
    }
}
