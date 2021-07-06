using System;

namespace Library
{
    public class StartGameHandler : AbstractHandler
    {
        public StartGameHandler()
        : base(new PositioningVesselsHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command == ("start") && player.IsWaitingForStartGame())
            {
                Room room = Rooms.Instance.GetRoomByHost(player);
                if (room != null)
                {
                    player.SendMessage("Comando /start recibido");
                    room.StartGame();
                    player.NextState();
                }
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}