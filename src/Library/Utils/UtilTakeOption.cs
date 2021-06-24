using System.Collections.ObjectModel;

namespace Library
{
    public class UtilTakeOption
    {
        public int TakeOption(ReadOnlyCollection<string> options, IPrinter clientP, IReader clientR)
        {
            int index = 1;
            foreach (string option in options)
            {
                clientP.Print(index + " " + option);
                index++;
            }
            return clientR.ReadInt(1, options.Count, clientP, "") - 1;
        }
    }
}