using System.IO;

namespace Library
{
    public class AddCommandToString : AbstractCommandsToString
    {
        public AddCommandToString()
        :base(new NextCommandToString())
        {
        }
        public override string ToString(string command, string lang)
        {
            if (command.ToLower() == "add")
            {
                return File.ReadAllLines(@"..\..\..\language\"+lang+@"\Commands.txt")[3];
            }
            else
            {
                return this.SendNext(command, lang);
            }
        }
    }
}