using System;
using System.Collections.Generic;

namespace Library
{
    public class NullMessageHandler : AbstractMessageHandler
    {
        public NullMessageHandler()
        :base(null)
        {
        }
        public override string[] MessagesOf(IPhase phase, string lang)
        {
            throw new NotImplementedException();
        }
    }   
}