using System.IO;

namespace Library
{
    public class NextCommandToString : AbstractCommandsTranslate
    {
        public NextCommandToString()
        :base(new ShowItemsCommandToString())
        {
        }
        public override string Translate(string command, string lang)
        {
            if (command.ToLower() == "next")
            {
                return File.ReadAllLines(@"..\..\language\"+lang+@"\Commands.txt")[4];
            }
            else
            {
                return this.SendNext(command, lang);
            }
        }
    }
}