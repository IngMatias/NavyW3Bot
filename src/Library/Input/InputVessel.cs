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