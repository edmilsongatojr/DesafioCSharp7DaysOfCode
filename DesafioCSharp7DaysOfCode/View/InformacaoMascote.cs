using DesafioCSharp7DaysOfCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode
{
    partial class Program
    {
        public static void InformacaoesMascoteAdotado()
        {
            Banner();
            //Mascote mascote = new Mascote();
            //mascote = mascote.CarregarDadosMascote();

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
