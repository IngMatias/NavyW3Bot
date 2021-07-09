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
            if (command.Equals("next") && player.Phase is PositioningVesselsPhase)
            {
                /*Vessel aux = new Vessel();
                VesselsToString aux2 = new VesselsToString();
                player.SendMessage(aux2.ToString(aux.Next(player.Vessels)));*/
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}