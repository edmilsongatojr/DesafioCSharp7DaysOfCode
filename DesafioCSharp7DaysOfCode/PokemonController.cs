using DesafioCSharp7DaysOfCode.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioCSharp7DaysOfCode
{
    public class PokemonController
    {
        public static int Offset => (int)EnumConfig.Offset;
        public static int Limit => (int)EnumConfig.Limit;
        public static int CountIndice { get; set; }

        public static List<MainPokemon> CarregaMainPokemons(int offset, int limit)
        {
            RestResponse response = PokemonService.ComunicaAPIPokemons($"?offset={offset}&limit={limit}");
            MainPokemon mainPokemonJsonList = JsonConvert.DeserializeObject<MainPokemon>(response.Content);
            List<MainPokemon> listaMainPokemon = new List<MainPokemon>() { mainPokemonJsonList };
            return listaMainPokemon;
        }
        public static List<Pokemon> CarregaListaPokemons()
        {
            List<MainPokemon> mainPokemons = CarregaMainPokemons((int)EnumConfig.Offset, (int)EnumConfig.Limit);
            List<Pokemon> listaPokemon = new List<Pokemon>();
            CarregaResultPokemons(mainPokemons, listaPokemon);
            return listaPokemon;
        }
        public static List<DadosPokemon> CarregaDadosPokemon()
        {
            List<DadosPokemon> listaDadosPokemons = new List<DadosPokemon>();

            for (int i = 0; i < (int)EnumConfig.Limit; i++)
            {
                RestResponse response = CarregaIdPokemon();
                if (!response.IsSuccessful)
                {
                    continue;
                }
                else
                {
                    DadosPokemon dadosPokemons = JsonConvert.DeserializeObject<DadosPokemon>(response.Content);
                    listaDadosPokemons.Add(dadosPokemons);
                }

            }
            return listaDadosPokemons;
        }
        private static RestResponse CarregaIdPokemon()
        {
            int indiceLimite = TrataIndiceEndPointPokemon();
            int indice = 1;

            if (CountIndice <= indiceLimite)
            {
                indice += Offset + CountIndice;
                CountIndice++;
                return PokemonService.ComunicaAPIPokemons(indice.ToString());
            }
            return null;
        }
        public static int TrataIndiceEndPointPokemon()
        {
            var indice = 0;
            if (Offset.Equals(Limit)) indice = Offset;
            else if (Offset < Limit) indice = Limit - Offset;
            else if (Offset > Limit) indice = Limit;
            return indice;
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


    }
}
