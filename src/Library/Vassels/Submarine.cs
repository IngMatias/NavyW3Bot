namespace Library
{
    public class Submarine : AbstractVessels
    {
        public Submarine()
        :base()
        {
            this.state = new int[4];
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