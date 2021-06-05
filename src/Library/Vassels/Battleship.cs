using System;
using System.Collections.Generic;

namespace Library
{
    public class Battleship : AbstractVessels
    {
        public Battleship()
        : base()
        {
            this.state = new int[6];
            this.InitState(1);
        }
        public void LaunchMissile(Table table, int x, int y)
        {
            table.MissileAt(x, y);
            table.RandomMissile();
            table.RandomMissile();

        }
    }
}
