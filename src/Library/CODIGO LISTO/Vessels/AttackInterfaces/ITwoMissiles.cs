namespace Library
{
    public interface ITwoMissiles : IAttacker
    {
        public void LaunchMissile(AbstractTable table, int x1, int y1, int x2, int y2);
    }
}