using DesafioCSharp7DaysOfCode.Models;
using System;
using System.Collections.Generic;

namespace DesafioCSharp7DaysOfCode
{
    partial class Program
    {
        private static List<MainPokemon> mainPokemons { get; set; }
        public static void Inicializa()
        {
            mainPokemons = PokemonController.CarregaMainPokemons((int)EnumConfig.Offset, (int)EnumConfig.Limit);
        }

        public static void TelaInicial()
        {

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
