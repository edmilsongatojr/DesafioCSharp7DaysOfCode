using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode
{
    partial class Program
    {
        private static string GeraConteudo(char stringTexto, int quantidadeRepeticao)
        {
            return new String(stringTexto, quantidadeRepeticao).ToString();
        }

        public static void SairDoJogo()
        {
            Console.WriteLine("Saindo do jogo Tamaggtchi...");

        }
    }
}