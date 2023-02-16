using AutoMapper;
using DesafioCSharp7DaysOfCode.AutoMapperController;
using DesafioCSharp7DaysOfCode.Controllers;
using DesafioCSharp7DaysOfCode.Models;
using System;

namespace DesafioCSharp7DaysOfCode.Views
{
    partial class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Inicializa();
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                TratamentoController.Mensagem(ex);
            }

        }
    }
}
