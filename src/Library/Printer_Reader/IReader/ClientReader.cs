using System;

namespace Library
{
    public class ClientReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
        public string Read(string msg)
        {
            IPrinter printer = new ClientPrinter();
            printer.Print(msg);
            return Console.ReadLine();
        }
    }
}