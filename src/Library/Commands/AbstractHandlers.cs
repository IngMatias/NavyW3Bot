namespace Library
{
    public abstract class AbstractHandlers
    {
        private AbstractHandlers nextHandler;
        public abstract void DoCommand(string Handler, IPrinter clientP);
    }
}