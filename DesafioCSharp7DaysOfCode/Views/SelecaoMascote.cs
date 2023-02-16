using AutoMapper;
using DesafioCSharp7DaysOfCode.Controllers;
using DesafioCSharp7DaysOfCode.Models;
using DesafioCSharp7DaysOfCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode.Views
{
    partial class Program
    {
        public static void SelecaoMascote()
        {
            try
            {
                Banner();
                Console.WriteLine($"|[==================[ SELECAO DE MASCOTE ]==================]|{GeraConteudo('_', 55)}\n");
                Console.WriteLine($"{Jogador.Nome}! Escolha seu mascote:");
                int itemCount = 1;
                string especieMascote, nomeMascote;
                List<string> listaEspecieMascote = CarregaNaTelaListaPokemons(ref itemCount);
                ValidaOpcaoSelecaoMascote(listaEspecieMascote, out especieMascote, out nomeMascote);
                ValidaSelecaoTelaSelecaoMascote(nomeMascote, especieMascote);
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
        }
        private static List<string> CarregaNaTelaListaPokemons(ref int itemCount)
        {
            List<string> listaEspecieMascote = new List<string>();
            try
            {
                foreach (var pokemon in PokemonService.ListaPokemonsDisponiveis())
                {
                    string opcaoEspecie = $" {itemCount} - {pokemon.Name}";
                    Console.WriteLine(opcaoEspecie);
                    listaEspecieMascote.Add(opcaoEspecie);
                    itemCount++;
                }
                Console.Write("| Selecione a opção o Mascote: ");

            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
            return listaEspecieMascote;
        }
        private static void ValidaOpcaoSelecaoMascote(List<string> listaEspecieMascote, out string especieMascote, out string nomeMascote)
        {
            Regex regex = new Regex("[1-9,0]");
            especieMascote = string.Empty;
            nomeMascote = string.Empty;
            try
            {
                var opcao = Console.ReadLine();
                foreach (var item in listaEspecieMascote)
                {
                    if (item.Contains(opcao))
                    {
                        especieMascote = item.Substring(5).ToUpper();
                    }
                }
                if (regex.IsMatch(opcao))
                {

                    if (!string.IsNullOrEmpty(opcao) && Convert.ToInt32(opcao) <= PokemonService.ListaPokemonsDisponiveis().Count && regex.IsMatch(opcao))
                    {
                        Console.WriteLine($"| Ótima Escolha! O {especieMascote} é um excelente mascote!!!!");
                        Console.WriteLine("| Agora precisamos de um Nome para ele! Que nome deseja colocar?");
                        Console.Write($"| O nome do mascote {especieMascote}: ");
                        nomeMascote = Console.ReadLine();
                        Console.WriteLine($"| Nome Maravilhoso! O {especieMascote} adorou!");
                    }
                    else
                    {
                        especieMascote = null;
                    }
                }
                else
                {
                    especieMascote = null;
                }
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
                especieMascote = null;

            }
        }
        private static void ValidaSelecaoTelaSelecaoMascote(string nomeMascote, string especieMascote)
        {
            bool validaOpcao = true;
            try
            {
                while (validaOpcao)
                {
                    if (!String.IsNullOrEmpty(especieMascote))
                    {
                        validaOpcao = false;
                        DadosPokemon dadosPokemon = new DadosPokemon(nomeMascote, especieMascote);
                        mascote = Mapper.Map<Mascote>(dadosPokemon);
                        mascote.SalvarDadosMascote();
                        //mascote.CarregarDadosMascote();
                        Console.WriteLine("| Informações Salvas com Sucesso!");
                        Console.WriteLine("| Iremos Retornar ao Menu Principal :) Pressione qualquer tecla para Retornarmos...");
                        Console.ReadKey();
                        Banner();
                        MenuPrincipal();
                    }
                    else
                    {
                        Console.WriteLine($"\n| Nao encontrei a opcao informada!\n| {Jogador.Nome} Selecione uma especie de mascote valida!\n\n| Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Banner();
                        SelecaoMascote();
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
