using DesafioCSharp7DaysOfCode.Controllers;
using DesafioCSharp7DaysOfCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode.Views
{
    partial class Program
    {
        private static void InteracoesMascote()
        {
            Banner();
            Console.WriteLine($" 1 - Alimentar o {mascote.Nome}.");
            Console.WriteLine($" 2 - Brincar com o {mascote.Nome}.");
            Console.WriteLine($" 3 - Medicar o {mascote.Nome}.");
            Console.WriteLine($" 4 - Colocar o {mascote.Nome} para dormir.");
            Console.WriteLine($" 0 - Retornar ao menu principal.");
            Console.WriteLine(GeraConteudo('_', 120));
            Console.Write("| O que deseja fazer? Opção: ");
            var opcao = Console.ReadLine();

            bool validaOpcao = true;
            MascoteController mascoteController = new MascoteController(mascote);
            while (validaOpcao)
            {

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine($"| O {mascote.Nome} está se alimentando!");
                        Thread.Sleep(1000);
                        Console.WriteLine($"| O {mascote.Nome} diz: {mascote.Nome}...{mascote.Nome}...{mascote.Nome.ToUpper()}");
                        mascoteController.AlimentarMascote();
                        break;
                    case "2":
                        Console.WriteLine($"| O {mascote.Nome} está se brincando :)!");
                        Thread.Sleep(1000);
                        Console.WriteLine("Brinca...");
                        Thread.Sleep(1000);
                        Console.Write("Brinca...");
                        Console.WriteLine($"| O {mascote.Nome} diz: {mascote.Nome}...{mascote.Nome}...{mascote.Nome.ToUpper()}");
                        mascoteController.BrincarMascote();
                        break;
                    case "3":
                        Console.WriteLine($"| Estamos Medicando o {mascote.Nome}! :(");
                        Thread.Sleep(1000);
                        Console.WriteLine($"| O {mascote.Nome} diz: {mascote.Nome}...{mascote.Nome}...{mascote.Nome.ToUpper()}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"| O {mascote.Nome} se sente bem melhor :)");
                        mascoteController.MedicarMascote();
                        break;
                    case "4":
                       
                        mascoteController.NinarMascote();
                        break;
                    case "0":
                        MenuPrincipal();
                        break;
                    default:
                        Console.WriteLine($"\n| Nao encontrei a opcao informada!\n| {Jogador.Nome} Selecione um opcao valida!\n\n");
                        break;
                }
                Console.WriteLine("| Pressione qualquer tecla para retornar ao menu de interação...");
                Console.ReadKey();
                Banner();
                InteracoesMascote();
                validaOpcao = false;
            }
        }
    }
}
