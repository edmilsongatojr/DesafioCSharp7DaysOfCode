using RestSharp;
using System;

namespace DesafioCSharp7DaysOfCode
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(GETListaPokemon());
            Console.ReadKey();
        }

        public static string GETListaPokemon()
        {
            string urlApi = "https://pokeapi.co/api/v2/pokemon/?offset=20&limit=20%22";
            var client = new RestClient(urlApi);
            var request = new RestRequest(Method.Get.ToString());

            return request.ToString();
        }


        public class Rootobject
        {
            public int count { get; set; }
            public string next { get; set; }
            public string previous { get; set; }
            public Result[] results { get; set; }
        }

        public class Result
        {
           
        }

    }
}
