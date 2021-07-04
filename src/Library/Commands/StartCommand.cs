namespace Library
{
    public class StartHandler : AbstractHandlers
    {
        private AbstractHandlers startCommand;
        public StartHandler()
        {
            this.startCommand = new JoinCommand();
        }
        public override void DoCommand(string command, IPrinter clientP)
        {
            startCommand.DoCommand(command, clientP); 
        }
    }
}