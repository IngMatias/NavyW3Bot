using System;
using System.IO;

namespace Library
{
    public class StartMessageHandler : AbstractMessageHandler
    {
        public StartMessageHandler()
        :base(new NullMessageHandler())
        {
        }
        public override string Message(IMessage message, string lang)
        {
            if (message is StartMessage)
            {
                return File.ReadAllLines(@"..\..\..\..\..\language\"+lang+@"\Messages.txt")[0];
            }
            else
            {
                return this.SendNext(message, lang);
            }
        }
    }
}