using DesafioCSharp7DaysOfCode.Models;
using DesafioCSharp7DaysOfCode.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DesafioCSharp7DaysOfCode.Views
{
    partial class Program
    {
        static Mascote mascote = new Mascote();
        private static List<MainPokemon> mainPokemons { get; set; }
        public static void Inicializa()
        {
            mainPokemons = PokemonService.CarregaMainPokemons((int)EnumConfig.Offset, (int)EnumConfig.Limit);
            Banner();
            PerguntaNomeJogador();
            MenuPrincipal();
        }
        private static void Banner()
        {
            Console.Clear();
            Console.WriteLine(GeraConteudo('_', 120));
            Console.WriteLine();
            Console.WriteLine("############  ##########  ############  ##########  ##########  ##########  ###########  ##########  ##      ##  ##");
            Console.WriteLine("     ##       ##      ##  ##   ##   ##  ##      ##  ##       #  ##      ##       ##      ##          ##      ##  ##");
            Console.WriteLine("     ##       ##      ##  ##   ##   ##  ##      ##  ##          ##      ##       ##      ##          ##      ##  ##");
            Console.WriteLine("     ##       ##########  ##   ##   ##  ##########  ##   #####  ##      ##       ##      ##          ##########  ##");
            Console.WriteLine("     ##       ##      ##  ##   ##   ##  ##      ##  ##      ##  ##      ##       ##      ##          ##      ##  ##");
            Console.WriteLine("     ##       ##      ##  ##   ##   ##  ##      ##  ##      ##  ##      ##       ##      ##          ##      ##  ##");
            Console.WriteLine("     ##       ##      ##  ##   ##   ##  ##      ##  ##########  ##########       ##      ##########  ##      ##  ##");
            Console.WriteLine();
            Console.WriteLine(GeraConteudo('_', 120));
            Console.WriteLine("                                                                                       vs1.1 Console - by Jimmy :) ");
            if (!String.IsNullOrEmpty(Jogador.Nome))
            {
                Console.WriteLine($" | Jogador Ativo: {Jogador.Nome.ToUpper()} |");
                if (!string.IsNullOrEmpty(mascote.Nome) && mascote.DadosMascote != null)
                {
                    VisualizadorDeStatus();
                }
            }
            else
            {
                Console.WriteLine("Olá! Bem vindo ao Tamagotchi Pokemon x!\n");
            }
            Console.WriteLine(GeraConteudo('_', 120));

        }
        private static void PerguntaNomeJogador()
        {
            Console.Write($"Para começar, diga seu nome Jogador: ");
            Jogador.Nome = Console.ReadLine();
            Banner();
        }
        private static void MenuPrincipal()
        {
            Console.WriteLine($"|[==================[ MENU PRINCIPAL ]==================]|{GeraConteudo('_', 62)}\n");
            Console.WriteLine($"Olá {Jogador.Nome}! Vamos Brincar?");
            int countOpcao = 1;
            bool interacao = false;
            if (string.IsNullOrEmpty(mascote.Nome) && mascote.DadosMascote is null)
            {
                Console.WriteLine($" {countOpcao} - Bora adotar um bicho virtual?");
            }
            else
            {
                Console.WriteLine($" {countOpcao} - Informações do Mascote");
                Console.WriteLine($" {countOpcao + 1} - Jogar com o {mascote.Nome}");
                interacao = true;
            }
            Console.WriteLine(" 0 - Sair do Jogo.");
            Console.Write("| Escolha a opção desejada: ");
            var opcao = Console.ReadLine();
            opcao = TrataOpcaoMenuInicial(interacao, opcao);
            ValidaSelecaoMenuPrincipal(opcao);
        }
        private static void ValidaSelecaoMenuPrincipal(string opcao)
        {
            bool validaOpcao = true;

            while (validaOpcao)
            {

                switch (opcao)
                {
                    case "1":
                        SelecaoMascote();
                        break;
                    case "2":
                        InformacaoesMascoteAdotado();
                        break;
                    case "3":
                        InteracoesMascote();
                        break;
                    case "0":
                        SairDoJogo();
                        break;
                    default:
                        Console.WriteLine($"\n| Nao encontrei a opcao informada!\n| {Jogador.Nome} Selecione um opcao valida!\n\n| Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Banner();
                        MenuPrincipal();
                        break;
                }
                validaOpcao = false;
            }
        }
    }
}







