using DesafioCSharp7DaysOfCode.Controllers;
using System;

namespace DesafioCSharp7DaysOfCode.Views
{
    partial class Program
    {
        public static void InformacaoesMascoteAdotado()
        {
            try
            {
                Banner();
                Console.WriteLine($"Nome do Mascote: {mascote.Nome}");
                CarregaNaTelaDadosMascote();
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
            finally
            {
                Banner();
                MenuPrincipal();
            }

        }
        private static void CarregaNaTelaDadosMascote()
        {
            try
            {
                Console.WriteLine($"    Especie: {mascote.Name.ToUpper()}");
                Console.WriteLine($"    Idade: {mascote.ObterIdade()}");
                Console.WriteLine($"        ID: {mascote.Id}");
                Console.WriteLine($"        Alimentação:");

                int countAlimento = 1;
                foreach (var alimento in mascote.Alimentacao)
                {
                    Console.WriteLine($"            {countAlimento} - {alimento}");
                    countAlimento++;
                }

                Console.WriteLine($"        Status de Saude: {mascote.StatusSaude}");
                Console.WriteLine($"        Altura: {mascote.Height}");
                Console.WriteLine($"        Peso: {mascote.Weight}");
                Console.WriteLine($"        Habilidades:");

                int countHabilidade = 1;
                foreach (var habilidade in mascote.Abilities)
                {
                    Console.WriteLine($"            Habilidade {countHabilidade}: {habilidade.Ability.Name.ToUpper()}");
                    countHabilidade++;
                }
                Console.WriteLine(GeraConteudo('_', 120));
                Console.WriteLine("Pressione qualquer tecla para retornar ao Menu Principal...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
        }
        private static void VisualizadorDeStatus()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine($" [ Nome: {mascote.Nome} ] | [ Idade: {mascote.ObterIdade()} ] | [ Especie: {mascote.Especie} ]");
                Console.WriteLine($" [ Energia: {mascote.StatusEnergia} ] | [ Saude: {mascote.StatusSaude} ] | [ Fome: {mascote.StatusFome} ] | [ Humor: {mascote.StatusHumor} ]");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }
            finally
            {
                if (mascote.Name != null)
                {
                    mascote.SalvarDadosMascote();
                }
            }
        }
    }
}
