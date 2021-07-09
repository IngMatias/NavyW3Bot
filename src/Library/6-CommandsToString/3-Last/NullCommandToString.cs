using System;

namespace Library
{
    public class NullCommandToString : AbstractCommandsToString
    {
        public NullCommandToString()
        :base(null)
        {
        }
        public override string ToString(string command, string lang)
        {
            throw new NotImplementedException();
        }
    }
}