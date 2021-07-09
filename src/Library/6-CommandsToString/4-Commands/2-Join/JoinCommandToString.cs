using System.IO;

namespace Library
{
    public class JoinCommandToString : AbstractCommandsToString
    {
        public JoinCommandToString()
        :base(new AddCommandToString())
        {
        }
        public override string ToString(string command, string lang)
        {
            if (command.ToLower() == "join")
            {
                return File.ReadAllLines(@"..\..\..\language\"+lang+@"\Commands.txt")[2];
            }
            else
            {
                return this.SendNext(command, lang);
            }
        }
    }
}