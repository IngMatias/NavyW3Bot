
using System;
using System.Collections.Generic;

namespace Library
{
    public class ShowEnemiesHandler : AbstractHandler
    {
        public ShowEnemiesHandler()
        : base(new ShowMyTableHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.StartsWith("show ") && player.Phase is AttackPhase && Rooms.Instance.IsPlaying(player) && command.Split(" ").Length == 2)
            {
                if (Rooms.Instance.IsPlayingWith(player, command.Split(" ")[1]))
                {
                    Rooms.Instance.ShowTableOf(player, command.Split(" ")[1]);
                }
                else
                {
                    player.SendMessage(command.Split(" ")[1] + " no es un enemigo");
                }
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}
