using DesafioCSharp7DaysOfCode.Connections;
using DesafioCSharp7DaysOfCode.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

namespace DesafioCSharp7DaysOfCode.Services
{
    public class PokemonService
    {

        public static int Offset => (int)EnumConfig.Offset;
        public static int Limit => (int)EnumConfig.Limit;
        public static int CountIndice { get; set; }

        public static List<MainPokemon> CarregaMainPokemons(int offset, int limit)
        {
            RestResponse response = PokemonsConnections.ComunicaAPIPokemons($"?offset={offset}&limit={limit}");
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
                if (!response.IsSuccessful || response == null)
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
                return PokemonsConnections.ComunicaAPIPokemons(indice.ToString());
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
        public static List<Pokemon> CarregaResultPokemons(List<MainPokemon> mainPokemons, List<Pokemon> listaPokemon)
        {
            foreach (var mainPokemon in mainPokemons)
            {
                foreach (var result in mainPokemon.Results)
                {
                    listaPokemon.Add(result);
                }
            }
            return listaPokemon;
        }
        public static List<Pokemon> ListaPokemonsDisponiveis()
        {
            return CarregaResultPokemons(CarregaMainPokemons((int)EnumConfig.Offset, (int)EnumConfig.Limit), CarregaListaPokemons());
        }

    }
}