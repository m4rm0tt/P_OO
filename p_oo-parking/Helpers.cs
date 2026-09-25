using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace p_oo_parking
{
    static public class Helpers
    {
        static public bool PlateValidation(string p)
        {
            bool validity = false;

            string patern = @"^[A-Z]{2}-\d{3,5}$";

            return validity = Regex.IsMatch(p, patern);
        }

        public static ConsoleKeyInfo? ReadInput()
        {
            if (Console.KeyAvailable)
            {
                return Console.ReadKey(true);
            }
            return null;
        }
    }
}
