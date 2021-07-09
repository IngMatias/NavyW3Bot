
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
            if(command.Equals("showitems") && player.Phase is PositioningItemsPhase)
            {
                player.SendMessage(player.VesselsEItemsToString(player.Language));
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}
