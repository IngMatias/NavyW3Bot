namespace Library
{
    public class HeavyCruiser : AbstractVessels
    {
        public HeavyCruiser()
        :base()
        {
            this.state = new int[3];
            this.InitState(2);
        }
        public void LaunchMissile(Table table, int x, int y)
        {
            table.MissileAt(x, y);
            table.MissileAt(x, y);
        }
    }
}