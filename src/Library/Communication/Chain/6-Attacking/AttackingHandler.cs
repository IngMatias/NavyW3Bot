
using System;
using System.Collections.Generic;

namespace Library
{
    public class AttackingHandler : AbstractHandler
    {
        public AttackingHandler()
        : base(new ShowEnemiesHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.Equals("attack") && player.IsAttacking() && command.Split(" ").Length == 4)
            {

            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}
