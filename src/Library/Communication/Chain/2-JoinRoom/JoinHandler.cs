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
            //Console.Write("Pasa por join " + player.State + "\n");
            if (command.StartsWith("join ") && player.IsWaitingForJoin() && command.Split(" ").Length == 2)
            {
                player.SendMessage("Comando /join recibido");
                Rooms.Instance.AddPlayer(player, Int32.Parse(command.Split(" ")[1]));
                player.SendMessage("Has sido agregado correctamente.");
                player.NextState();
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}