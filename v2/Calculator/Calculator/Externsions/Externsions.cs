using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Externsions
{
    public static class Externsions
    {
        public static string Extend(this string input, string arg)
        {
            return String.Format(input, arg);
        }

        public static bool In<T>(this T input, IEnumerable<T> args)
        {
            return args.Contains<T>(input);
        }

        public static string RemoveLastChar(this string input)
        {
            return input.Length > 0 ? input.Remove(input.Length - 1, 1) : input;
        }
    }
}
