using System;

namespace Library
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
        public string Read(string msg)
        {
            IPrinter printer = new ConsolePrinter();
            printer.Print(msg);
            return Console.ReadLine();
        }
    }
}