
// S -  SRP: Esta clase tiene la responsabilidad de conseguir la informacion para agregar un barco 
//      (posicion en el tablero y orientacion).

// O -  OCP: No se cumple, para cambiar la forma de elegir la posicion y orientacion de estos
//      se necesita modificar este codigo.

// L -  LSP: No se aplica.

// I -  ISP: Se depende de operaciones de IPrinter e IReader de las que no se utilizan todas.

// D -  DIP: Se depende solo de abstracciones.

//      Expert: No aplica.

//      Polymorphism: No es utilizado.

//      Creator: No se usa.

using System.Collections.Generic;

namespace Library
{
    public class InputAddVessel
    {
        private (int, int) TakePosition(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int x = clientR.ReadInt(1, table.XLength(), clientP, "En que posicion X desea colocar el barco?: ");
            int y = clientR.ReadInt(1, table.YLength(), clientP, "En que posicion Y desea colocar el barco?: ");
            return (x - 1, y - 1);
        }
        private bool TakeOrientation(IPrinter clientP, IReader clientR)
        {
            int orientation = clientR.ReadInt(1, 2, clientP, "Orientacion Vertical: 1 Horizontal: 2:");
            return orientation == 1;
        }
        public bool AddVessel(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR)
        {
            (int, int) position = TakePosition(table, clientP, clientR);
            bool orientation = TakeOrientation(clientP, clientR);
            return table.AddVessel(position.Item1, position.Item2, vessel, orientation);
        }
    }
}