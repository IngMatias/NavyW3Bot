namespace Library
{
    public abstract class AbstractPreviousPhase
    {
        private AbstractPreviousPhase _next;
        public AbstractPreviousPhase(AbstractPreviousPhase next)
        {
            this._next = next;
        }
        public abstract IPhase PreviousPhase(IPhase phase);
        public IPhase SendNext(IPhase phase)
        {
            return this._next.PreviousPhase(phase);
        }
    }
}