// S - SRP: Esta clase define el comportamiento de los barcos de un tablero, es decir, tiene la responsabilidad de 
//           definir los metodos por los cuales el tablero podra manejar la informacion de sus barcos.

// O - OCP: Se cumple. Si se deseara añadir un comportamiento al tablero, se debería crear una nueva clase abtracta con el
//           comportamiento definido a esta nueva clase y hacer que AbstractVesselSaver lo herede.
//           Recordar que Table es una clase compuesta por:
//           AbstractVesselSaver -> AbstractField -> AbstractAttackable -> AbstractTable -> Table
//           AbstractVesselSaver es la última clase en la cadena, si esta clase hereda un comportamiento, todas las clases
//           que hereden a esta úlitma tambien habrán heredado el nuevo comportamiento, haciendo que se cumpla el principio.       

// L - LSP: Se cumple. Cualquier objeto Table puede ser sustituido por el tipo AbstractVesselSaver, mas si esto se hiciera no se
//           contaría con todos los comportamientos de las clases que heredan a esta.

// I - ISP: No se aplica.

// D - DIP: Se aplica DIP, esto se puede ver en el diseño de Table (clase de bajo nivel), esta depende de abstracciones
//           no de clases de bajo nivel.

// Expert: Esta clase es la experta en el manejo de los barcos, es decir la experta en agregar/quitar barcos del tablero
//          y de guardar el registro de los barcos que tiene cada tablero.

// Polymorphism: No se aplica.

// Creator: No se aplica.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Library
{
    public abstract class AbstractVesselSaver
    {
        protected Dictionary<(int, int), AbstractVessel> vessels;
        public ReadOnlyCollection<AbstractVessel> GetVessels()
        {
            return this.vessels.Values.ToList<AbstractVessel>().AsReadOnly();
        }
        public AbstractVessel GetVessel((int, int) key)
        {
            return this.vessels[key];
        }
        protected AbstractVesselSaver()
        {
            this.vessels = new Dictionary<(int, int), AbstractVessel>();
        }
        protected bool AddVessel(int up, int left, AbstractVessel vessel)
        {
            this.vessels.Add((up, left), vessel);
            return true;
        }
        protected bool RemoveVessel((int, int) key)
        {
            this.vessels.Remove(key);
            return true;
        }
    }
}