using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class InputTable
    {
        public int TakeOptionTable(ReadOnlyCollection<AbstractTable> opcions, IPrinter clientP, IReader clientR)
        {
            // Dependencias.
            UtilTakeOption util = new UtilTakeOption();
            
            List<string> opcionsString = new List<string>();
            foreach (AbstractTable table in opcions)
            {
                opcionsString.Add("Table.");
            }
            return util.TakeOption(opcionsString.AsReadOnly(), clientP, clientR);
        }
    }
}