using System;

namespace Library
{
    public class StartGameHandler : AbstractHandler
    {
        public StartGameHandler()
        : base(new NextVesselHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command.Equals("start") && player.Phase is WaitingForStartGamePhase)
            {

                if (Rooms.Instance.Start(player))
                {
                    Rooms.Instance.SendAllByHost("Ha iniciado el juego.", player);
                }
                else
                {
                    player.SendMessage("Debes ser host para inicial el juego.");
                }
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}