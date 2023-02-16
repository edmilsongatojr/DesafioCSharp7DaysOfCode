using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode.Views
{
    partial class Program
    {
        private static string GeraConteudo(char stringTexto, int quantidadeRepeticao)
        {
            return new String(stringTexto, quantidadeRepeticao).ToString();
        }
        private static string TrataOpcaoMenuInicial(bool interacao, string opcao)
        {
            if (interacao && !opcao.Equals("0"))
            {
                opcao = (Convert.ToInt32(opcao) + 1).ToString();
            }
            return opcao;
        }
        public static void SairDoJogo()
        {
            Console.WriteLine("Saindo do jogo Tamaggtchi...");

        }

    }
}