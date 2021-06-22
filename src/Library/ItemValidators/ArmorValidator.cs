namespace Library
{
    public class ArmorValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table)
        {
            return vesselToAdd.Items[position] == null;
        }
    }
}