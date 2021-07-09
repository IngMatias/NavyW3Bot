using System.IO;

namespace Library
{
    public class TableOfCommandToString : AbstractCommandsToString
    {
        public TableOfCommandToString()
        :base(new NullCommandToString())
        {
        }
        public override string ToString(string command, string lang)
        {
            if (command.ToLower() == "tableof")
            {
                return File.ReadAllLines(@"..\..\..\language\"+lang+@"\Commands.txt")[6];
            }
            else
            {
                return this.SendNext(command, lang);
            }
        }
    }
}