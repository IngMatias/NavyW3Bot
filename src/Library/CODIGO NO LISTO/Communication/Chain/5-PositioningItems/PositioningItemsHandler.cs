using System;
using System.Collections.Generic;

namespace Library
{
    public class PositioningItemsHandler : AbstractHandler
    {
        public PositioningItemsHandler()
        : base(new ShowVesselsHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command.StartsWith("add") && player.IsPositioningItem() && command.Split(" ").Length == 3)
            {
                int vesselInt = StringToInt.Convert(command.Split(" ")[1], player) - 1;
                int position = StringToInt.Convert(command.Split(" ")[2], player) - 1;

                player.AddItem(position,Item.Instance.Next(player) ,player.Vessels[vesselInt]);
                player.SendMessage(player.Vessels.ToString());

                if (player.CountItems() >= 0)
                {
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