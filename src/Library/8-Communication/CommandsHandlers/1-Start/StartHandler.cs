using System;

namespace Library
{
    public class StartHandler : AbstractHandler
    {
        public StartHandler()
        :base(new CreateHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command.Equals("start") && player.Phase is WaitingForStartPhase)
            {
                player.NextState();
                player.SendMessage("");
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}