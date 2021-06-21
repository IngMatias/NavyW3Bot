using System.Collections.ObjectModel;

namespace Library
{
    public class UtilTakeOption
    {
        public int TakeOption(ReadOnlyCollection<string> opciones,IPrinter clientP, IReader clientR)
        {
            int index = 1;
            foreach (string option in opciones)
            {
                clientP.Print(index + " " + option);
                index ++;
            }
            return clientR.ReadInt(1, opciones.Count, clientP, "") - 1;
        }
    }
}