using System;
using System.Collections.Generic;

namespace Library
{
    public class PositioningVesselsHandler : AbstractHandler
    {
        public PositioningVesselsHandler()
        : base(new NextItemHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command.StartsWith("add ") && player.IsPositioningVessel() && command.Split(" ").Length == 4)
            {
                int x = StringToInt.Convert(1, player.XLength(), command.Split(" ")[1], player, "La primera coordenada del ataque") - 1;
                int y = StringToInt.Convert(1, player.YLength(), command.Split(" ")[2], player, "La segunda coordenada del ataque") - 1;
                int ori = StringToInt.Convert(0, 1, command.Split(" ")[3], player, "La orientacion del barco");

                if (x != -2 && y!= -2 && ori != -1)
                {
                    Vessel aux = new Vessel();
                    player.AddVessel(x, y, aux.Next(player.Vessels), ori == 1);
                    player.SendMessage(player.EmojiTable());

                    if (aux.Next(player.Vessels) == null)
                    {
                        player.NextState();
                    }
                }
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}