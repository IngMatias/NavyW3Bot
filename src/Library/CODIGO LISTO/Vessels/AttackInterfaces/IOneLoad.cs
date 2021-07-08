namespace Library
{
    public interface IOneLoad : IAttacker
    {
        public void ThrowLoad(AbstractTable table, int x, int y);
    }
}