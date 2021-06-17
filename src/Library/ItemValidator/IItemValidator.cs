namespace Library
{
    public interface IItemValidator
    {
        public bool IsAddable(AbstractVessels vasselToAdd, ITable table);
    }
}