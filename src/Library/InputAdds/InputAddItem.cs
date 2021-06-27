
// S -  SRP: Esta clase tiene la responsabilidad de conseguir la informacion para agregar un item 
//      (seleccionar el barco y la posicion en el barco).

// O -  OCP: No se cumple, para cambiar la forma de seleccion entre barcos y la posicion en estos
//      se necesita modificar este codigo.

// L -  LSP: No se aplica.

// I -  ISP: Se depende de operaciones de IPrinter e IReader de las que no se utilizan todas.

// D -  DIP: El metodo TakeVessel depende de VesselsToString que no es una abastraccion.

//      Expert: No aplica.

//      Polymorphism: No es utilizado.

//      Creator: Esta clase crea instancias de VesselsToString, ya que se utiliza de forma cercana.

using System.Collections.Generic;
using System.Collections.ObjectModel;

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