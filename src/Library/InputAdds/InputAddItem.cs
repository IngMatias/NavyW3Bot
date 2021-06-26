using System.Collections.Generic;
using System.Collections.ObjectModel;

// S - SRP: Esta clase tiene la responsabilidad de colocar u eliminar un item.

// O - OCP: No cumple OCP, si se quiere agregar un nuevo ataque es necesario modificar el codigo.

// L - LSP: No aplica.

// I - ISP: No aplica.

// D - DIP: InputAddItem depende de AbstractVessel por lo tanto cumple con DIP.

// Expert: Esta clase conoce si el item se coloca o no por lo tanto tiene la responsabilidad de
//         agregarlo u eliminarlo.

// Polymorphism: La operacion TakePosition y TakeVessel son polimorficas.

// Creator: Esta clase usa al patron ya que crea instancias de clases cercanas.

namespace Library
{
    public class InputAddItem
    {
        private int TakePosition(AbstractVessel vessel, IPrinter clientP, IReader clientR)
        {
            int x = clientR.ReadInt(0, vessel.Length(), clientP, "En que posicion desea colocar el item? 0 para eliminar el item: ");
            if (x == 0)
            {
                throw new DeleteItemException();
            }
            return x - 1;
        }
        private int TakeVessel(ReadOnlyCollection<AbstractVessel> vessels, IPrinter clientP, IReader clientR)
        {
            // Dependencias.
            VesselsToString vesselsName = new VesselsToString();

            int index = 1;
            foreach (AbstractVessel vessel in vessels)
            {
                clientP.Print(index + " " + vesselsName.NameOf(vessel));
                index++;
            }
            int x = clientR.ReadInt(0, vessels.Count, clientP, "En que barco deseas colocar el item? 0 para eliminar el item: ");
            if (x == 0)
            {
                throw new DeleteItemException();
            }
            return x - 1;
        }
        public bool AddItem(IItem item, ReadOnlyCollection<AbstractVessel> vessels, AbstractTable table, IItemValidator validator, IPrinter clientP, IReader clientR)
        {
            int vessel = this.TakeVessel(vessels, clientP, clientR);
            int position = this.TakePosition(vessels[vessel], clientP, clientR);
            return vessels[vessel].AddItem(position, item, table, validator);
        }
    }
}