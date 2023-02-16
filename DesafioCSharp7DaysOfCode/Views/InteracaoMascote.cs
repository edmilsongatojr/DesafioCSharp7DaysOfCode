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
            try
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
                            mascoteController.AlimentarMascote();
                            break;
                        case "2":
                            mascoteController.BrincarMascote();
                            break;
                        case "3":
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
                            Banner();
                            InteracoesMascote();
                            break;
                    }
                    validaOpcao = false;
                }
            }
            catch (Exception ex)
            {

                TratamentoController.Mensagem(ex);
            }
        }
    }
}
