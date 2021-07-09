using System;

namespace Library
{
    public class HeadMessageHandler : AbstractMessageHandler
    {
        public HeadMessageHandler()
        :base(new StartMessageHandler())
        {
        }
        public override string Message(IMessage message, string lang)
        {
            return this.SendNext(message, lang);
        }
    }
}