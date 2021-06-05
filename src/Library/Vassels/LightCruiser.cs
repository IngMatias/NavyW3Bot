namespace Library
{
    public class LightCruiser : AbstractVessels
    {
        public void LaunchMissile(Table table, int x, int y)
        {
            table.MissileAt(x, y);
        }
        public void ThrowLoad(Table table, int x, int y)
        {
            table.LoadAt(x, y);
        }
    }
}
