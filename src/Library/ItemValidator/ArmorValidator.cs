namespace Library
{
    public class ArmorValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, ITable table)
        {
            return vesselToAdd.Items[position] == null; 
        }
    }
}