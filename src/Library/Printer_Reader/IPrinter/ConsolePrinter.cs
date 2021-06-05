using System;

namespace Library
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string ToPrint)
        {
            Console.WriteLine(ToPrint);
        }
    }
}