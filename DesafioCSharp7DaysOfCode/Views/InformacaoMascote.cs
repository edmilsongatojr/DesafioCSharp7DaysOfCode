using System;

namespace DesafioCSharp7DaysOfCode.Views
{
    partial class Program
    {
        public static void InformacaoesMascoteAdotado()
        {
            Banner();
            Console.WriteLine($"Nome do Mascote: {mascote.Nome}");
            CarregaNaTelaDadosMascote();
            Banner();
            MenuPrincipal();

        }
        private static void CarregaNaTelaDadosMascote()
        {
            foreach (var pokemon in mascote.DadosMascote)
            {
                Console.WriteLine($"    Especie: {pokemon.Name.ToUpper()}");
                Console.WriteLine($"    Idade: {mascote.Idade}");
                Console.WriteLine($"        ID: {pokemon.Id}");
                Console.WriteLine($"        Alimentação:");

                int countAlimento = 1;
                foreach (var alimento in mascote.Alimentacao)
                {
                    Console.WriteLine($"            {countAlimento} - {alimento}");
                    countAlimento++;
                }

                Console.WriteLine($"        Status de Saude: {mascote.StatusSaude}");
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
            Console.WriteLine(GeraConteudo('_', 120));
            Console.WriteLine("Pressione qualquer tecla para retornar ao Menu Principal...");
            Console.ReadKey();
        }

        private static void VisualizadorDeStatus()
        {
            foreach (var dados in mascote.DadosMascote)
            {
                Console.WriteLine();
                Console.WriteLine($" [ Nome: {mascote.Nome} ] | [ Idade: {mascote.Idade} ] | [ Especie: {dados.Name} ]");
                Console.WriteLine($" [ Energia: {mascote.StatusEnergia} ] | [ Saude: {mascote.StatusSaude} ] | [ Fome: {mascote.StatusFome} ] | [ Humor: {mascote.StatusHumor} ]");
                Console.WriteLine();
            }


        }
    }
}
