using DesafioCSharp7DaysOfCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DesafioCSharp7DaysOfCode
{
    partial class Program
    {
        private static List<MainPokemon> mainPokemons { get; set; }
        public static void Inicializa()
        {
            mainPokemons = PokemonController.CarregaMainPokemons((int)EnumConfig.Offset, (int)EnumConfig.Limit);
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
            Console.WriteLine($"Olá {Jogador.Nome}! Escolha a opcao desejada:");
            Console.WriteLine(" 1 - Bora adotar um bicho virtual?");
            Console.WriteLine(" 2 - Ver dados do seu Bicho Virtual.");
            Console.WriteLine(" 0 - Sair do Jogo.");
            Console.Write("Opcao: ");
            var opcao = Console.ReadLine();
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
        public static void ListaDadosPokemon()
        {
            Mascote mascote = new Mascote("João Teles Abacadabra", "ekans");
            Console.WriteLine($"Nome do Mascote: {mascote.Nome}");

            foreach (var pokemon in mascote.DadosMascote)
            {
                Console.WriteLine($"    Especie: {pokemon.Name.ToUpper()}");
                Console.WriteLine($"    Idade: {pokemon.Idade}");
                Console.WriteLine($"        ID: {pokemon.Id}");
                Console.WriteLine($"        Alimentação:");

                int countAlimento = 1;
                foreach (var alimento in pokemon.Alimentacao)
                {
                    Console.WriteLine($"            {countAlimento} - {alimento}");
                    countAlimento++;
                }

                Console.WriteLine($"        Status de Saude: {pokemon.StatusSaude}");
                Console.WriteLine($"        Altura: {pokemon.Height}");
                Console.WriteLine($"        Peso: {pokemon.Weight}");
                Console.WriteLine($"        Habilidades:");

                int countHabilidade = 1;
                foreach (var habilidade in pokemon.Abilities)
                {
                    Console.WriteLine($"            Habilidade {countHabilidade}: {habilidade.Ability.Name.ToUpper()}");
                    countHabilidade++;
                }
            }
            Console.WriteLine("");

        }
    }
}







