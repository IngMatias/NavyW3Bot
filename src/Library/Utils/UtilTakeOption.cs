// S - SRP: Esta clase define un metodo que se encarga de imprimir las opciones y devolver el resultado que el 
//           el usuario elija.

// O - OCP: Se aplica debido a que al ser un comportamiento especifico se define en una clase para ser llamado,
//           cuando se necesiten nuevos comportamientos espesificos se deben implementar de la misma manera.

// L - LSP: No se aplica.

// I - ISP: No se aplica.

// D - DIP: No se aplica.

// Expert: No se aplica.

// Polymorphism: No se aplica.

// Creator: No se utiliza.

using System.Collections.ObjectModel;

namespace Library
{
    public class UtilTakeOption
    {
        public int TakeOption(ReadOnlyCollection<string> options, IPrinter clientP, IReader clientR)
        {
            int index = 1;
            foreach (string option in options)
            {
                clientP.Print(index + " " + option);
                index++;
            }
            return clientR.ReadInt(1, options.Count, clientP, "") - 1;
        }
    }
}