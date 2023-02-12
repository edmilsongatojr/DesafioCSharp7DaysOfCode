using DesafioCSharp7DaysOfCode.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode
{
    public class Program : PokemonService
    {
        static void Main(string[] args)
        {
            ListaDadosPokemon();
            Console.ReadKey();
        }


        public static void ListaDadosPokemon()
        {
            foreach (var item in PokemonController.CarregaMainPokemons((int)EnumConfig.Offset, (int)EnumConfig.Limit))
            {
                Console.WriteLine($"Contagem Total da Lista de Pokemons: {item.Count}");
                Console.WriteLine($"Contagem de Pokemons para Mascotes Disponiveis: {PokemonController.TrataIndiceEndPointPokemon()}");
                Console.WriteLine("Retorno Pokemons:");
                foreach (var pokemon in PokemonController.CarregaDadosPokemon())
                {
                    Console.WriteLine($"    Nome: {pokemon.Name}");
                    Console.WriteLine($"        ID: {pokemon.Id}");
                    Console.WriteLine($"        Altura: {pokemon.Height}");
                    Console.WriteLine($"        Peso: {pokemon.Weight}");
                    Console.WriteLine($"        Habilidades:");

                    int countHabilidade = 1;
                    foreach (var habilidade in pokemon.Abilities)
                    {
                        Console.WriteLine($"            Habilidade {countHabilidade}: {habilidade.Ability.Name}");
                        countHabilidade++;
                    }
                }
                Console.WriteLine("");
            }

        }

    }
}
