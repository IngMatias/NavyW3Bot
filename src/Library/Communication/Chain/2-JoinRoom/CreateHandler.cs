using System;

namespace Library
{
    public class CreateHandler : AbstractHandler
    {
        public CreateHandler()
        :base(new JoinHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command == ("create") && player.IsWaitingForJoin())
            {
                player.SendMessage("Comando /create recibido");
                player.SendMessage("Su Id de partida es: " + Rooms.Instance.AddSession(player));
                player.NextState();
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}