using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

// S - SRP: Esta interface se encarga de la responsabilidad de manejar el tablero.
// Si se es estricto hay mas de dos razones de cambio, si se desea cambiar el tamaño
// del tablero, agregar una nueva representacion en el mismo o cambiar el modo de agregado
// de barcos, por ejemplo permitiendo agregarse en el borde.
// Sin embargo no creemos que sea necesario romper esta unión.

// O - OCP: No se encuentra una aplicacion del principio OCP.

// L - LSP: No se encuentra una aplicacion del principio LSP.

// I - ISP: Table no respeta ISP, no hace uso de todas las operaciones de AbstractVessels.

// D - DIP: Table depende solo de abstracciones, se cumple DIP.

// Expert : Esta clase conoce el tablero, por lo tanto tiene todo lo relacionado con su Consulta y Tratamiento.
// Ademas conoce el lugar donde se hallan los barcos, por lo que tambien es responsable de realizar los ataques si corrsponde.

// Polimorfismo : No se usa polimorfismo.

// Creator : Se usa Creator en la creacion de la matriz table y el diccionario vessels.

namespace Library
{
    public interface ITable
    {
        public int XLength(); 
        public int YLength();
        public void Update(int x, int y, int data);

        public ReadOnlyCollection<AbstractVessels> GetVessels();
        public bool IsAVessel(int x, int y);
        public bool IsSomething(int x, int y);
        public bool IsEmpty();
        public bool AddVessel(int x, int y, AbstractVessels vessel, bool orientation);
        public void AttackAt(int x, int y, AbstractAttacker attack);
        public void RandomAttack(AbstractAttacker attack);
        public void RemoveVessel(int x, int y);
        public string StringTable();
    }
}