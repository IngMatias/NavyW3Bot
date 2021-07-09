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
            if (command.Equals("create") && player.Phase is WaitingForJoinPhase)
            {
                player.SendMessage("Su Id de partida es: " + Rooms.Instance.AddSession(player));
                player.SendMessage("Su partida se ha creado correctamente.");
                player.NextState();
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}