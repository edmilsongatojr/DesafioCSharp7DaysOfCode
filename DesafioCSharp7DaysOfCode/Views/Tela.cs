using AutoMapper;
using DesafioCSharp7DaysOfCode.AutoMapperController;
using DesafioCSharp7DaysOfCode.Controllers;
using DesafioCSharp7DaysOfCode.Models;
using DesafioCSharp7DaysOfCode.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace DesafioCSharp7DaysOfCode.Views
{
    partial class Program
    {
        static Mascote mascote = new Mascote();
        private static List<MainPokemon> MainPokemons { get; set; }

        public static void Inicializa()
        {
            AutoMapperUtil.InicializaAutoMapper();
            MainPokemons = PokemonService.CarregaMainPokemons((int)EnumConfig.Offset, (int)EnumConfig.Limit);
            VerificarDadosSalvos();
        }

        private static void VerificarDadosSalvos()
        {
            try
            {
                Mascote _mascote = new Mascote();
                Banner();
                _mascote.VerificaExistenciaJson();
                if (!mascote.ValidarDadosSalvos())
                {
                    PerguntaNomeJogador();
                    MenuPrincipal();
                }
                else
                {
                    Console.WriteLine("Olá Jogadpr! Verificamos que Encontramos alguns dados Salvos no MemoryCard do Tamagotchi :)");
                    Console.WriteLine("Deseja Continuar?");
                    Console.WriteLine(" 1 - Sim | 2 - Não");
                    Console.Write("Resposta: ");
                    var opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            
                            mascote = _mascote.CarregarDadosMascote();
                            MenuPrincipal();
                            break;
                        case "2":
                            PerguntaNomeJogador();
                            MenuPrincipal();
                            break;
                        default:
                            Console.WriteLine("Não compreendi a opção!");
                            VerificarDadosSalvos();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
        }

        private static void Banner()
        {
            try
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
                    if (!String.IsNullOrEmpty(mascote.Name))
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
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }

        }
        private static void PerguntaNomeJogador()
        {
            try
            {
                Banner();
                Console.Write($"Para começar, diga seu nome Jogador: ");
                Jogador.Nome = Console.ReadLine();
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
            finally { Banner(); }
        }
        public static void MenuPrincipal()
        {
            try
            {
                Banner();
                Console.WriteLine($"|[==================[ MENU PRINCIPAL ]==================]|{GeraConteudo('_', 62)}\n");
                Console.WriteLine($"Olá {Jogador.Nome}! Vamos Brincar?");
                int countOpcao = 1;
                bool interacao = false;
                if (String.IsNullOrEmpty(mascote.Name))
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
                ValidaSelecaoMenuPrincipal(opcao, interacao);
            }
            catch (Exception ex)
            {

                TratamentoController.Mensagem(ex);
            }
        }
        private static void ValidaSelecaoMenuPrincipal(string opcao, bool interacao)
        {
            try
            {
                bool validaOpcao = true;
                if (interacao == false && Convert.ToInt32(opcao) > 1)
                {
                    MenuPrincipal();
                    return;
                }
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
                            validaOpcao = false;
                            break;
                        default:
                            Console.WriteLine($"\n| Nao encontrei a opcao informada!\n| {Jogador.Nome} Selecione um opcao valida!\n\n| Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            Banner();
                            MenuPrincipal();
                            break;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
        }
    }
}







