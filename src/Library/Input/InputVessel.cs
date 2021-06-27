
// S -  SRP: Esta clase tiene la responsabilidad de transformar una lista de barcos en una de strings.

// O -  OCP: No se cumple, para cambiar la forma de seleccion entre barcos se necesita modificar este codigo.

// L -  LSP: No aplica.

// I -  ISP: Se depende de operaciones de IPrinter e IReader que no se utilizan.

// D -  DIP: El metodo TakeOptionVessel depende de abstracciones y UtilTakeOption que no lo es.

//      Expert: No aplica.

//      Polymorphism: No es utilizado.

//      Creator: Esta clase crea instancias de UtilTakeOption, ya que se utiliza de forma cercana.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class InputVessel
    {
        public int TakeOptionVessel(ReadOnlyCollection<AbstractVessel> opcions, IPrinter clientP, IReader clientR)
        {
            // Dependencias.
            UtilTakeOption util = new UtilTakeOption();
            
            List<string> opcionsString = new List<string>();
            foreach (AbstractVessel vessel in opcions)
            {
                opcionsString.Add(vessel.ToString());
            }
            return util.TakeOption(opcionsString.AsReadOnly(), clientP, clientR);
        }
    }
}