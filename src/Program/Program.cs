
using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

            IReader telegram = new ClientTelegramReader();
            telegram.StartRead();

            Console.ReadKey();

            telegram.StopRead();
        }
    }
}