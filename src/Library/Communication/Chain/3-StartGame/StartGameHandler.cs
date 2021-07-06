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
            if (command.Equals("start") && player.IsWaitingForStartGame())
            {
                Room room = Rooms.Instance.GetRoomByHost(player);
                if (room == null)
                {
                    player.SendMessage("Debes ser host para poder iniciar el juego.");
                }
                else
                {
                    room.StartGame();
                }   
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}