using System;

namespace Library
{
    public class Class1
    {
        public void SayHi()
        {
            Console.WriteLine("Hi");
            foreach ( int i in new int[5] )
            {
                Console.WriteLine(i);
            }
            
        }
    }
}