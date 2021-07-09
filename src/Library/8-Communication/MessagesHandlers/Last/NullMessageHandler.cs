using System;

namespace Library
{
    public class NullMessageHandler : AbstractMessageHandler
    {
        public NullMessageHandler()
        :base (null)
        {
        }
        public override string Message(IMessage message, string lang)
        {
            throw new NotImplementedException();
        }
    }
}