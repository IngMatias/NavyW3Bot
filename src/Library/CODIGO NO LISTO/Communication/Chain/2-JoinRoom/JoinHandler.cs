using System;

namespace Library
{
    public class JoinHandler : AbstractHandler
    {
        public JoinHandler()
        :base(new StartGameHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command.StartsWith("join") && player.IsWaitingForJoin() && command.Split(" ").Length == 2)
            {
                int roomId = StringToInt.Convert(command.Split(" ")[1], player);
                Rooms.Instance.AddPlayer(player, roomId);
                player.SendMessage("Has sido agregado correctamente.");
                Rooms.Instance.GetRoomById(roomId).SendAll("Se ha unido " + player.Name + " a la partida.");
                player.NextState();
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}