using System;

namespace Library
{
    public class Battleship : AbstractVessels
    {
        public void LaunchMissile(Table table, int x, int y)
        {
            table.MissileAt(x, y);
            this.RandomMisil(table);
            this.RandomMisil(table);

        }
    }
}
