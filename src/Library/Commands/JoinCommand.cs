namespace Library
{
    public class JoinCommand : AbstractCommand
    {
        private AbstractCommand nextCommand;
        public JoinCommand()
        {
            this.nextCommand = new NullCommand();
        }
        public override void DoCommand(string command, IPrinter clientP)
        {
            if (command.StartsWith("/join ") && command.Split(" ").Length==2)
            {
                clientP.Print(command.Split(" ")[1]);
            }
            else
            {
                nextCommand.DoCommand(command, clientP);
            }
        }
    }
}