namespace Library
{
    public class LightCruiser : AbstractVessels
    {
        public LightCruiser()
        :base()
        {
            this.state = new int[5];
            this.InitState(1);
        }
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