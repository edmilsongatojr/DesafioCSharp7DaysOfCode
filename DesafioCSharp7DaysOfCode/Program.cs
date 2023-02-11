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
    public class Program
    {
        static void Main(string[] args)
        {
            ListaDadosPokemon();
            Console.ReadKey();
        }

        private static RestResponse ComunicaAPIPokemons()
        {
            string urlApi = "https://pokeapi.co/api/v2/pokemon/?offset=20&limit=20";
            var client = new RestClient(urlApi);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            return response;
        }
        public static List<MainPokemon> CarregaMainPokemons()
        {
            RestResponse response = ComunicaAPIPokemons();


            MainPokemon mainPokemonJsonList = JsonConvert.DeserializeObject<MainPokemon>(response.Content);

            List<MainPokemon> listaMainPokemon = new List<MainPokemon>() { mainPokemonJsonList };

            return listaMainPokemon.ToList();
        }
        public static List<Pokemon> CarregaListaPokemons()
        {
            List<MainPokemon> mainPokemons = CarregaMainPokemons();
            List<Pokemon> listaPokemon = new List<Pokemon>();

            CarregaResultPokemons(mainPokemons, listaPokemon);

            return listaPokemon.ToList(); ;
        }
        private static void CarregaResultPokemons(List<MainPokemon> mainPokemons, List<Pokemon> listaPokemon)
        {
            foreach (var mainPokemon in mainPokemons)
            {
                for (int i = 0; i < mainPokemon.Results.Length; i++)
                {
                    listaPokemon.Add(mainPokemon.Results[i]);
                }

            }
        }
        public static void ListaDadosPokemon()
        {
            foreach (var item in CarregaMainPokemons())
            {
                Console.WriteLine(item.Count);
                Console.WriteLine(item.Previous);
                Console.WriteLine(item.Next);
                Console.WriteLine("Results Pokemons:");
                foreach (var pokemon in CarregaListaPokemons())
                {
                    Console.WriteLine($"      Nome: {pokemon.Name}");
                    Console.WriteLine($"      Url: {pokemon.Url}");
                }
                Console.WriteLine("");
            }

        }


    }
}
