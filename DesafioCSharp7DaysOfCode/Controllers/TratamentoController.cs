using DesafioCSharp7DaysOfCode.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode.Controllers
{
    public static class TratamentoController
    {
        public static void Mensagem(Exception exception)
        {
            try
            {
                Console.WriteLine($"\n\nHaa nao que pena! :( Encontramos uma Falha, mas não se preocupe, iremos reinciar a aplicação para voce :) \n" +
                         $"Se quiser saber mais sobre a mensagem de erro: {exception.Message}\n\n" +
                         $"Pressione algum tecla para prosseguir! xD");
                Console.ReadKey();
                Program.MenuPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao gerar Tratamento de erro:  {ex.Message}");
            }
        }
    }
}
