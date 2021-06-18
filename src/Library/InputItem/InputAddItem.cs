using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class InputAddItem
    {
        public int TakePosition(AbstractVessel vessel, IPrinter clientP, IReader clientR)
        {
            int x = clientR.ReadInt(1, vessel.Length(), clientP, "En que posicion desea colocar el item: ");
            return x - 1;
        }
        public int TakeVessel(ReadOnlyCollection<AbstractVessel> vessels, IPrinter clientP, IReader clientR)
        {
            int index = 1;
            foreach (AbstractVessel vessel in vessels)
            {
                clientP.Print(index + " " +vessel);
                index ++;
            }
            return clientR.ReadInt(1, vessels.Count, clientP, "En que barco deseas colocar el item: ") -1;
        }
        public bool AddItem(IItem item, ReadOnlyCollection<AbstractVessel> vessels, AbstractTable table, IItemValidator validator, IPrinter clientP, IReader clientR)
        {
            int vessel = this.TakeVessel(vessels, clientP, clientR);
            int position = this.TakePosition(vessels[vessel], clientP, clientR);
            return vessels[vessel].AddItem(position, item, table, validator);
        }
    }
}