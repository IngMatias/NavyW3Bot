using System;

namespace Library
{
    public class NullPreviousPhase : AbstractPreviousPhase
    {
        public NullPreviousPhase()
        :base(null)
        {
        }
        public override IPhase PreviousPhase(IPhase phase)
        {
            throw new NotImplementedException();
        }
    }
}