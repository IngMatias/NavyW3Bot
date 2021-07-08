
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
            // barco x y missil/load receptor
            if(command.StartsWith("attack") && player.IsAttacking() && player.IsAttacking() && command.Split(" ").Length == 5)
            {
                Room room = Rooms.Instance.GetRoomByPlaying(player);
                AbstractPlayer receptor = room.GetPlayerByName(command.Split(" ")[4]);

                // player.Attack(new Battleship(), Int32.Parse(command.Split(" ")[1]) , Int32.Parse(command.Split(" ")[2]), receptor);

                room.SendAll(player.Name + " ha atacado a " + receptor.Name);

                room.NextAttack();
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}
