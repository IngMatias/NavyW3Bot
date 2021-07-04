namespace Library
{
    public class NullHandler : AbstractHandlers
    {
        private AbstractHandlers nextHandler;
        public NullHandler()
        {
        }
        public override void DoCommand(string command, IPrinter clientP)
        {
            clientP.Print("Comando Incorrecto");
        }
    }
}