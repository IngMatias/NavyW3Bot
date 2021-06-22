using System;
using System.Collections.Generic;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            class1.SayHi();

            FirstPhase pha = new FirstPhase();
            AbstractTable tab = new Table();
            IPrinter p = new ClientPrinter();
            IReader r = new ClientReader();
            pha.Execute(tab,null,p,r);

            
        }
    }
}