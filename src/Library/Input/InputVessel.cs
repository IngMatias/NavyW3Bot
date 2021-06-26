using System.Collections.Generic;
using System.Collections.ObjectModel;

// S - SRP: Esta clase tiene la responsabilidad de colocar un barco en una posicion ingresada por el jugador

// O - OCP: 

// L - LSP: No se aplica

// I - ISP: No aplica.

// D - DIP: El metodo TakeOptionVessel depende de una clase abstracta por lo tanto cumple con DIP.

// Expert: Esta clase conoce las cordenadas por lo tanto puede cumplir con su responsabilidad.

// Polymorphism: La operacion Attack es polimorfica.

// Creator : Esta clase usa al patron ya que en TakeOptionVessel se crean instancias de clases cercanas.

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