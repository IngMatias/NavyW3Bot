using System;

namespace Library
{
    public class TelegramReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
        public string Read(string msg)
        {
            IPrinter printer = new TelegramPrinter();
            printer.Print(msg);
            return Console.ReadLine();
        }
    }
}
