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
            if (command == "start" && player.IsWaitingStart())
            {
                player.SendMessage("Comando /start recibido");
                player.NextState();
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}