namespace Library
{
    public class JoinCommand : AbstractHandlers
    {
        private AbstractHandlers nextCommand;
        public JoinCommand()
        {
            this.nextCommand = new NullHandler();
        }
        public override void DoCommand(string handler, IPrinter clientP)
        {
            if (handler.StartsWith("/join ") && handler.Split(" ").Length==2)
            {
                clientP.Print(handler.Split(" ")[2]);
            }
            else
            {
                nextCommand.DoCommand(handler, clientP);
            }
        }
    }
}