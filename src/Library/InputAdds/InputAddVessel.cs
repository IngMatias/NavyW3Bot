using System.Collections.Generic;

// S - SRP: Esta clase tiene la responsabilidad de colocar u eliminar un barco.

// O - OCP: No cumple OCP, si se quiere agregar un nuevo ataque es necesario modificar el codigo.

// L - LSP: No aplica.

// I - ISP: No aplica.

// D - DIP: InputAddItem depende de AbstractVessel por lo tanto cumple con DIP.

// Expert: Esta clase conoce si el item se coloca o no por lo tanto tiene la responsabilidad de
//         agregarlo u eliminarlo.

// Polymorphism: La operacion TakePosition y AddVessel son polimorficas.

// Creator: No aplica.

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