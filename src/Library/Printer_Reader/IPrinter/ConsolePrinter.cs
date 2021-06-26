// S - SRP: Esta clase define los metodos necesarios para comunicarnos desde el programa hacia un cliente. Este clase  
//           en particular define a la consola.

// O - OCP: No se utiliza.

// L - LSP: Cualquier objeto de este tipo puede ser sustituido por IPrinter.

// I - ISP: No se utiliza.

// D - DIP: Esta clase solo depende de clases de alto nivel.

// Expert: Esta clase es la experta en conocer los metodos necesarios para que el programa se pueda comunicar con el cliente.

// Polymorphism: Se definen las metodos orientado a el funcionamiento del cliente.

// Creator: No se utiliza.

using System;

namespace Library
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(object ToPrint)
        {
            Console.WriteLine(ToPrint);
        }
    }
}