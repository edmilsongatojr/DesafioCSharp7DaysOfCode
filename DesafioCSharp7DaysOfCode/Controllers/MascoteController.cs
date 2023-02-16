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

        public MascoteController(Mascote mascote)
        {
            Mascote = mascote;
        }
        internal void BrincarMascote()
        {
            try
            {
                Mascote.StatusHumor += 10;
                Mascote.StatusSaude++;
                Mascote.StatusFome += 20;
                Mascote.StatusEnergia -= 15;

                Console.WriteLine($"\n| O {Mascote.Nome} está brincando :)!");
                Thread.Sleep(1000);
                Console.Write("Brinca...");
                Thread.Sleep(1000);
                Console.Write("Brinca...");
                Console.WriteLine($"|-> {Mascote.Nome} Diz: {Mascote.Nome}...{Mascote.Nome}...{Mascote.Nome} :)");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }

        }
        internal void AlimentarMascote()
        {
            try
            {
                Console.WriteLine($"\n| O {Mascote.Nome} está feliz em ir se alimentar!");
                Thread.Sleep(1000);
                Console.WriteLine($"\n| O {Mascote.Nome} diz: {Mascote.Nome}...{Mascote.Nome}...{Mascote.Nome.ToUpper()}");
                Console.WriteLine($"| Qual Alimento deseja alimentar o {Mascote.Nome}?");
                int countOpcoes = 1;
                foreach (var alimento in Mascote.Alimentacao)
                {
                    Console.WriteLine($" {countOpcoes} - {alimento}.");
                    countOpcoes++;
                }
                Console.Write("Opção: ");
                var opcao = Console.ReadLine();

                Console.WriteLine($"O {Mascote.Nome} esta se Alimentando...");
                Thread.Sleep(1000);
                EnumAlimentos enumAllimentos;
                if (Enum.TryParse(opcao, out enumAllimentos))
                {
                    int opcaoInt = (int)enumAllimentos;
                    Mascote.StatusFome -= opcaoInt;
                }
                Console.WriteLine($"| O {Mascote.Nome} diz: {Mascote.Nome}...{Mascote.Nome}...{Mascote.Nome.ToUpper()}");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }

        }
        internal void NinarMascote()
        {
            try
            {
                if (Mascote.StatusEnergia.Equals(100))
                {
                    Console.WriteLine($"| O {Mascote.Nome} não tem sono! Ele quer consquistar o mundoo :) GrrahhH");

                }
                else
                {
                    Console.WriteLine($"| O {Mascote.Nome} está Dor....RonczZ!");
                    Thread.Sleep(1000);
                    Console.Write($"| z");
                    Thread.Sleep(1000);
                    Console.Write($"...zZ");
                    Thread.Sleep(1000);
                    Console.Write($"...Roonc");
                    Thread.Sleep(1000);
                    Console.WriteLine($"| O {Mascote.Nome} diz: {Mascote.Nome}...{Mascote.Nome}...{Mascote.Nome.ToUpper()}");
                    Mascote.StatusEnergia = 100;
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
        }
        internal void MedicarMascote()
        {
            try
            {
                Mascote.StatusHumor += 20;
                Mascote.StatusEnergia += (Mascote.StatusEnergia / 2);
                Mascote.StatusSaude = 100;
                Console.WriteLine($"\n| Estamos Medicando o {Mascote.Nome}! :(");
                Thread.Sleep(1000);
                Console.WriteLine($"\n| O {Mascote.Nome} diz: {Mascote.Nome}...{Mascote.Nome}...{Mascote.Nome.ToUpper()}");
                Thread.Sleep(1000);
                Console.WriteLine($"\n| O {Mascote.Nome} se sente bem melhor :)");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
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
