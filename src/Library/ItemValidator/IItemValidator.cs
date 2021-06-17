namespace Library
{
    public interface IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, ITable table);
    }
}