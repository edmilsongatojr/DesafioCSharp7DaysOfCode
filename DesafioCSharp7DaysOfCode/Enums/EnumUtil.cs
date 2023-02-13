using DesafioCSharp7DaysOfCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp7DaysOfCode
{
    public class EnumUtil
    {
        public static T GetRandomValue<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            Random random = new Random();
            T randomValue = (T)values.GetValue(random.Next(values.Length));
            return randomValue;
        }

        public static int GetTotal<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            return values.Length;
        }
    }
}
