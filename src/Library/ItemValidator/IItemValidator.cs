namespace Library
{
    public interface IItemValidator
    {
        public bool IsAddable(int position, AbstractVessels vesselToAdd, ITable table);
    }
}