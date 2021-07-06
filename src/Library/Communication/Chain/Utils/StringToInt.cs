using System;
using System.Collections.Generic;

namespace Library
{
    public class StringToInt
    {
        public static int Convert(string toConvert,AbstractPlayer player)
        {
            int converted = -1;
            try 
            {
                converted = Int32.Parse(toConvert);
            }
            catch(FormatException)
            {
                player.SendMessage("Debe ingresarte un numero entero: ");
            }
            return converted;
        }
    }
}