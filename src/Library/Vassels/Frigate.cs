using System;

namespace Library
{
    public class Frigate : AbstractVessels
    {
        public void LaunchMissile(Table table, int x1, int y1, int x2, int y2)
        {
            table.MissileAt(x1, y1);
            table.MissileAt(x2, y2);
            table.RandomMissile();
            table.RandomMissile();
        }
    }
}