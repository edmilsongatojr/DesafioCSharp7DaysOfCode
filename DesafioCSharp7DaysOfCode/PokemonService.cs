using DesafioCSharp7DaysOfCode.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace DesafioCSharp7DaysOfCode
{
    public class PokemonService
    {
        private static string urlapi = "https://pokeapi.co/api/v2/pokemon/";
        public static string UrlApi { get => urlapi; set => urlapi = value; }
        public static RestResponse ComunicaAPIPokemons(string endpoint)
        {
            RestClient client = RestClientApi(endpoint);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            return response;
        }
        private static RestClient RestClientApi(string endpoint)
        {
            return new RestClient(ConcatenaEndpoint(endpoint));
        }
        private static string ConcatenaEndpoint(string endpoint)
        {
            return $"{UrlApi}{endpoint}";
        }
        

    }
}