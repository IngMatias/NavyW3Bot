namespace Library
{
    public abstract class AbstractCommand
    {
        private AbstractCommand nextCommand;
        public abstract void DoCommand(string command, IPrinter clientP);
    }
}