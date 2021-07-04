namespace Library
{
    public class NullCommand : AbstractCommand
    {
        private AbstractCommand nextCommand;
        public NullCommand()
        {
        }
        public override void DoCommand(string command, IPrinter clientP)
        {
            clientP.Print("Comando Incorrecto");
        }
    }
}