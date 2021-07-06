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
            if (command.Equals("start") && player.IsWaitingStart())
            {
                player.NextState();
                player.SendMessage("Se ha recibido correctamente el mensaje.");
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}