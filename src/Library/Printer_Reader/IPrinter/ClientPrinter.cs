using System;

namespace Library
{
    public class ClientPrinter : IPrinter
    {
        public void Print(string ToPrint)
        {
            Console.WriteLine(ToPrint);
        }
    }
}
