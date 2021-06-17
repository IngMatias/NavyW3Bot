using System;

namespace Library
{
    public class ClientReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
        public string Read(IPrinter printer, string msg)
        {
            printer.Print(msg);
            return Console.ReadLine();
        }
    }
}