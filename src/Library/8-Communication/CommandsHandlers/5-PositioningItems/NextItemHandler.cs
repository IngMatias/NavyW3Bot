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
            AbstractCommandsTranslate translate = new HeadCommandsToString();
            string[] message = new HeadMessageHandler().MessagesOf(player.Phase, player.Language);

            if(command.Equals("next") && player.Phase is PositioningItemsPhase)
            {
                AbstractIItemsToString itemsToString = new HeadIItemsToString();
                player.SendMessage("Su siguiente item, mi lord: " + 
                    itemsToString.ToString(Item.Instance.Next(player),player.Language));
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}
