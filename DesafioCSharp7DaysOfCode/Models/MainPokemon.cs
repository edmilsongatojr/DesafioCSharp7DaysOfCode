using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode.Models
{
    public class MainPokemon
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public Pokemon[] Results { get; set; }
    }
}
