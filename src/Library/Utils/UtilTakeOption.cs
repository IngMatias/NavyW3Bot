
// S - SRP: Esta clase define un metodo que se encarga de imprimir las opciones y devolver el resultado que el 
//     el usuario elija.

// O -  OCP: No se aplica, para agregar una forma diferente de obtener una opcion hay que modificar este codigo.

// L -  LSP: No se aplica.

// I -  ISP: No se aplica.

// D -  DIP: No se aplica.

//      Expert: No se aplica.

//      Polymorphism: No se aplica.

//      Creator: No se utiliza.

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