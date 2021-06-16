using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            class1.SayHi();

            Table tab = new Table();
            AbstractVessels bar = new Battleship();
            AbstractVessels sub = new Submarine();
            tab.AddVessel(1,1,bar,true);
            tab.AddVessel(3,1,sub,true);

            tab.AttackAt(1,1,new LoadAttack());
            tab.AttackAt(1,2,new MissileAttack());
            tab.AttackAt(3,1,new MissileAttack());

            Console.WriteLine(tab.StringTable());
        }
    }
}