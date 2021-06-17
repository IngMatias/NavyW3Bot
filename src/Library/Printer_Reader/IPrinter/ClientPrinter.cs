using System;

namespace Library
{
    public class ClientPrinter : IPrinter
    {
        public void Print(object ToPrint)
        {
            Console.WriteLine(ToPrint);
        }
    }
}