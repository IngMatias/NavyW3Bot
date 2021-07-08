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
            if (command.StartsWith("join ") && player.IsWaitingForJoin() && command.Split(" ").Length == 2)
            {
                int roomId = StringToInt.Convert(1,Rooms.Instance.Count() ,command.Split(" ")[1], player, "El cuarto");
                
                if (roomId != -1)
                {
                    Rooms.Instance.AddPlayer(player, roomId);
                    player.SendMessage("Has sido agregado correctamente.");
                    Rooms.Instance.SendAllById("Se ha unido " + player.Name + " a la partida.", roomId);
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