using System;
using System.Collections.Generic;

namespace Library
{
    public class NextVesselHandler : AbstractHandler
    {
        public NextVesselHandler()
        : base(new PositioningVesselsHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command.Equals("next") && player.IsPositioningVessel())
            {
                player.SendMessage(player.Vessels);
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}