
using System;
using System.Collections.Generic;

namespace Library
{
    public class ShowItemsHandler : AbstractHandler
    {
        public ShowItemsHandler()
        : base(new AttackingHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.Equals("showitems") && player.IsPositioningItem())
            {
                player.SendMessage(player.VesselsEItemsString());
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}
