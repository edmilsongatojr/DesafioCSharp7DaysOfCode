using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode.Connections
{
    public class PokemonsConnections
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
