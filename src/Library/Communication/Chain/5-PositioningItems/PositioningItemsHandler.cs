using System;
using System.Collections.Generic;

namespace Library
{
    public class PositioningItemsHandler : AbstractHandler
    {
        public PositioningItemsHandler()
        : base(new NullHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command.StartsWith("addat") && player.IsPositioningItem() && command.Split(" ").Length == 3)
            {
                int vesselInt = StringToInt.Convert(command.Split(" ")[1], player) - 1;
                int position = StringToInt.Convert(command.Split(" ")[2], player) - 1;
                player.AddItem(position,Item.Next() ,player.Vessels[vesselInt]);
                
                player.SendMessage(player.Vessels);
            }
            else
            {
                this.SendNext(command, player);
            }

            if (command == "getvessels" && player.IsPositioningItem())
            {
                player.SendMessage(player.Vessels);
            }
        }
    }
}