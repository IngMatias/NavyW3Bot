using System.IO;

namespace Library
{
    public class MyTableCommandToString : AbstractCommandsToString
    {
        public MyTableCommandToString()
        :base(new TableOfCommandToString())
        {
        }
        public override string ToString(string command, string lang)
        {
            if (command.ToLower() == "mytable")
            {
                return File.ReadAllLines(@"..\..\..\language\"+lang+@"\Commands.txt")[5];
            }
            else
            {
                return this.SendNext(command, lang);
            }
        }
    }
}