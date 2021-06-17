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

            AbstractVessels bar = new Battleship(); // Largo 6
            AbstractVessels pun = new Puntoon(); 

            IItem hack = new Hackers();
            IItem kong = new Kong();

            IItem hack2 = new Hackers();

            Console.WriteLine( pun.AddItem(0,hack,null, new HackersValidator()));
            Console.WriteLine( bar.AddItem(0,kong,null,new KongValidator()));
        }
    }
}