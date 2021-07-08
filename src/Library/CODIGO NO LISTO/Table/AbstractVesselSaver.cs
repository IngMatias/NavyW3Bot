
// S -  SRP: Esta clase define los metodos para el almacenamiento de barcos dentro del tablero.

// O -  OCP: Se cumple. Si se deseara añadir una forma de almacenamiento basta con crear una nueva clase.

// L -  LSP: Se cumple. Cualquier objeto que herede esta clase es y debe ser un subtipo de esta.

// I -  ISP: No se aplica.

// D -  DIP: Esta clase depende solamente de abstracciones.

//      Expert: Esta clase conoce los los barcos y su posicion, por lo tanto se encarga de manejarla. 

//      Polymorphism: No se aplica.

//      Creator: No se aplica.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Library
{
    public abstract class AbstractVesselSaver
    {
        protected Dictionary<(int, int), AbstractVessel> _vessels;
        public ReadOnlyCollection<AbstractVessel> GetListOfVessels()
        {
            return this._vessels.Values.ToList<AbstractVessel>().AsReadOnly();
        }
        protected AbstractVessel GetVessel((int, int) key)
        {
            return this._vessels[key];
        }
        protected AbstractVesselSaver()
        {
            this._vessels = new Dictionary<(int, int), AbstractVessel>();
        }
        protected bool AddVessel(int up, int left, AbstractVessel vessel)
        {
            this._vessels.Add((up, left), vessel);
            return true;
        }
        protected bool RemoveVessel((int, int) key)
        {
            this._vessels.Remove(key);
            return true;
        }
    }
}