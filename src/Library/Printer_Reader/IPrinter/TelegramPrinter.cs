using System;

namespace Library
{
    public class TelegramPrinter : IPrinter
    {
        public void Print(string ToPrint)
        {
            Console.WriteLine(ToPrint);
        }
    }
}
