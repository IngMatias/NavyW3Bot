namespace Library
{
    public interface IOneMissile : IAttacker
    {
        public void LaunchMissile(AbstractTable table, int x, int y);
    }
}