namespace Library
{
    public class HeavyCruiser : AbstractVessels
    {
        public void LaunchMissile(Table table, int x, int y)
        {
            table.MissileAt(x, y);
            table.MissileAt(x, y);
        }
    }
}