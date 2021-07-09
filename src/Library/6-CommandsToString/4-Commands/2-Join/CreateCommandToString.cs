using System.IO;

namespace Library
{
    public class CreateCommandToString : AbstractCommandsToString
    {
        public CreateCommandToString()
        :base(new JoinCommandToString())
        {
        }
        public override string ToString(string command, string lang)
        {
            if (command.ToLower() == "create")
            {
                return File.ReadAllLines(@"..\..\..\language\"+lang+@"\Commands.txt")[1];
            }
            else
            {
                return this.SendNext(command, lang);
            }
        }
    }
}