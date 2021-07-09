using System;
using System.Collections.Generic;

namespace Library
{
    public class NextItemHandler : AbstractHandler
    {
        public NextItemHandler()
        : base(new PositioningItemsHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.Equals("next") && player.IsPositioningItem())
            {
                ItemsToString itemsToString = new ItemsToString();
                player.SendMessage("Su siguiente item, mi lord: " + itemsToString.ToString(Item.Instance.Next(player)));
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}
