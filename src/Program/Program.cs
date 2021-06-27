using System;
using System.Collections.Generic;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            IRound game = new Game();
            IPrinter clientP = new ClientPrinter();
            IReader clientR = new ClientReader();

            Table tab1 = new Table();
            game.AddPlayer(tab1);
            Table tab2 = new Table();
            game.AddPlayer(tab2);

            game.Execute(clientP, clientR);

        }
    }
}