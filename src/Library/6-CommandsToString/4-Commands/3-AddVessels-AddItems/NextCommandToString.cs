using System.IO;

namespace Library
{
    public class NextCommandToString : AbstractCommandsToString
    {
        public NextCommandToString()
        :base(new MyTableCommandToString())
        {
        }
        public override string ToString(string command, string lang)
        {
            if (command.ToLower() == "next")
            {
                return File.ReadAllLines(@"..\..\..\language\"+lang+@"\Commands.txt")[4];
            }
            else
            {
                return this.SendNext(command, lang);
            }
        }
    }
}