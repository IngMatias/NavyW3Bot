
using System;
using System.Collections.Generic;

namespace Library
{
    public class ShowEnemiesHandler : AbstractHandler
    {
        public ShowEnemiesHandler()
        : base(new ShowTableOfHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.Equals("showenemies") && player.IsPositioningItem())
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
