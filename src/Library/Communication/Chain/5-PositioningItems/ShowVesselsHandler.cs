
using System;
using System.Collections.Generic;

namespace Library
{
    public class ShowVesselsHandler : AbstractHandler
    {
        public ShowVesselsHandler()
        : base(new AttackingHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.Equals("showvessels") && player.IsPositioningItem())
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
