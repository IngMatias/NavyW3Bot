using System;
using System.Collections.Generic;

namespace Library
{
    public class PositioningVesselsHandler : AbstractHandler
    {
        public PositioningVesselsHandler()
        : base(new NextItemHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.StartsWith("add") && player.IsPositioningVessel() && command.Split(" ").Length == 4)
            {
                int x = StringToInt.Convert(command.Split(" ")[1], player) - 1;
                int y = StringToInt.Convert(command.Split(" ")[2], player) - 1;
                bool ori = StringToInt.Convert(command.Split(" ")[3], player) == 1;

                player.AddVessel(x,y,Vessel.Next(player.Vessels),ori);
                player.SendMessage(player.Table);
                
                if (Vessel.Next(player.Vessels) == null)
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