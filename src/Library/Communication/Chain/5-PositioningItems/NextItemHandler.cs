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
                Item next = Item.Instance;
                player.SendMessage(next.Next(player));
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}
